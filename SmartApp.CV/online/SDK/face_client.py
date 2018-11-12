import os
import cv2
import requests
try:
    import json
except ImportError:
    import simplejson as json

API_HOST = 'https://api-eu.faceplusplus.com/facepp/v3/'

class Facepp_Client(object):

    def __init__(self, api_key=None, api_secret=None):

        api_key = os.getenv('FACEpp_KEY', None) if api_key==None else api_key
        api_secret = os.getenv('FACEpp_SECRET', None) if api_secret==None else api_secret

        if not api_key or not api_secret:
            raise AttributeError('Missing api_key or api_secret argument')

        self.api_key = api_key
        self.api_secret = api_secret

        self.url_params = { 'api_key': api_key, 'api_secret': api_secret}
        self.detect_params = {}

    def _sendRequest(self, *args, **kwargs):
        jr = json.loads(requests.post(*args, **kwargs).text)
        err = jr.get("error_message")
        if err: raise ValueError(err)
        return jr

    def setParamsDetect(self, return_landmark = 0, return_attributes = "gender,age,smiling,emotion", calculate_all = 0, face_rectangle = None):
        """
            set attribute to be returned in the response
            for a complete list of attributes and returned json see: https://console.faceplusplus.com/documents/5679127

            params:
                attributes: list of attributes to return
        """
        _all = "gender,age,smiling,headpose,facequality,blur,eyestatus,emotion,ethnicity,beauty,mouthstatus,eyegaze,skinstatus"

        if not isinstance(return_landmark, int) or return_landmark < 0 or return_landmark > 2:
            raise AttributeError("return_landmark must be an int between 0 and 2. See docs for meaning of value.")
        else: self.detect_params.update({"return_landmark": return_landmark})

        if not isinstance(return_attributes, str):
            raise TypeError("return_attributes should be a str.")
        else: self.detect_params.update({"return_attributes": _all if return_attributes.lower() == "all" else return_attributes })

        if not isinstance(calculate_all, int) or not calculate_all in range(2):
            raise AttributeError("calculate_all must be an int between 0 and 1. See docs for meaning of value.")
        else:
            self.detect_params.update({"calculate_all": calculate_all})

        if face_rectangle:
            if not isinstance(face_rectangle, str):
                raise TypeError("face_rectangle should be a str.")
            else:
                self.detect_params.update({"face_rectangle": face_rectangle})

    def detect(self, frame = None, file = None, return_landmark = 0, return_attributes = "gender,age,smiling,emotion", calculate_all = 0, face_rectangle = None):
        """
            Face detection
            for a complete list of attributes and returned json see: https://console.faceplusplus.com/documents/5679127

            params:
                frame: matrix-like object representing a single frame
                File: file object, file descriptor or filepath of the image
                attributes: list of attributes to return, default = [gender,age,smiling,emotion]

            return:
                json object
        """
        url = API_HOST + 'detect'
        params = self.url_params

        if not frame and not file:
                raise AttributeError("Missing frame or file argument. At least one must be set.")

        self.setParamsDetect(return_landmark, return_attributes, calculate_all, face_rectangle)
        params.update(self.detect_params)

        if frame is not None:
            data = cv2.imencode('.jpg', frame)[1]

        if file is not None:
            if isinstance(file, str):
                data = open(file, 'rb')
            else:
                data = file

        return self._sendRequest(url, params = params, files = {'image_file': data})

    def search(self, face_token = None, image_url = None, image_file = None, image_base64 = None, faceset_token = None, outer_id = None, return_result_count = 1):
        url = API_HOST + "search"
        params = self.url_params
        file = None

        if not face_token and not image_url and image_file is None and not image_base64:
            raise AttributeError('Missing face_token or image_url or image_file or image_base64 argument. At least one must be set.')

        if face_token:
            if isinstance(face_token, str):
                params.update({'face_token': face_token})
            else:
                raise AttributeError("face_token must be a string.")
        elif image_url:
            if isinstance(image_url, str):
                params.update({'image_url': image_url})
            else:
                raise AttributeError("face_token must be a string.")
        elif not image_file is None:
            if isinstance(image_file, str):
                try:
                    file = {'image_file': open(file, 'rb')}
                except OSError:
                    raise AttributeError("There was an error during opening file, check if path is valid.")
            else:
                file = {'image_file': image_file}
        else:
            raise AttributeError("image_base64 not yet implement.")

        if outer_id:
            params.update({'outer_id': outer_id})
        elif faceset_token:
            params.update({'faceset_token': faceset_token})
        else:
            raise AttributeError('You must define a unique outer_id or face_token.')

        if return_result_count <= 0 or return_result_count > 5:
            raise AttributeError('return_result_count can be between [1,5]. The default value is 1.')
        else:
            params.update({'return_result_count': return_result_count})

        return self._sendRequest(url, params = params, files = file)

    def addFace(self, face_tokens, faceset_token = None, outer_id = None):
        url = API_HOST + "faceset/addface"
        params = self.url_params

        if not faceset_token and not outer_id:
            raise AttributeError('Missing faceset_token or outer_id argument. At least one must be set.')

        if face_tokens:
            if isinstance(face_tokens, list):
                if len(face_tokens) < 5:
                    params.update({'face_tokens': ",".join(face_tokens)})
                else:
                    raise AttributeError('face_tokens array must be length at most 5.')
            elif isinstance(face_tokens, str):
                params.update({'face_tokens': face_tokens})
            else:
                raise AttributeError('face_tokens should be a string or a list of string. You provided a ' + type(face_tokens).__name__ + 'instead.')

        if outer_id:
            params.update({'outer_id': outer_id})
        elif faceset_token:
            params.update({'faceset_token': faceset_token})
        else:
            raise AttributeError('You must define a unique outer_id or face_token.')

        return self._sendRequest(url, params = params)

    def removeFace(self, face_tokens, faceset_token = None, outer_id = None):
        """
            params:
                face_tokens(str or list(str)):
                    if this string passed "RemoveAllFaceTokens", all the face_token within FaceSet will be removed.
        """

        url = API_HOST + "faceset/removeface"
        params = self.url_params

        if face_tokens:
            if isinstance(face_tokens, list):
                if len(face_tokens) < 1000:
                    params.update({'face_tokens': ",".join(face_tokens)})
                else:
                    raise AttributeError('face_tokens array must be length at most 1000.')
            elif isinstance(face_tokens, str):
                params.update({'face_tokens': face_tokens})
            else:
                raise AttributeError('face_tokens should be a string or a list of string. You provided a ' + type(face_tokens).__name__ + 'instead.')
        if outer_id:
            params.update({'outer_id': outer_id})
        elif faceset_token:
            params.update({'faceset_token': faceset_token})
        else:
            raise AttributeError('You must define a unique outer_id or face_token.')

        return self._sendRequest(url, params = params)

    def setUserID(self, face_token, faceset_token = None, user_id = None):
        url = API_HOST + "faceset/setuserid"
        params = self.url_params

        if not face_token and not faceset_token and not user_id:
            raise AttributeError('You must define all the params')

        if isinstance(face_token, str):
            params.update({'face_token': face_token})
        else:
            raise AttributeError('face_token should be a str. You provided a ' + type(face_token).__name__ + 'instead.')

        if isinstance(faceset_token, str):
            params.update({'faceset_token': faceset_token})
        else:
            raise AttributeError('faceset_token should be a str. You provided a ' + type(faceset_token).__name__ + 'instead.')

        if isinstance(user_id, str):
            params.update({'user_id': user_id})
        else:
            raise AttributeError('user_id should be a str. You provided a ' + type(user_id).__name__ + 'instead.')

        return self._sendRequest(url, params = params)

    """
    --------------------API to manage Facesets---------------------------------
    """

    def addFace(self, face_tokens, faceset_token = None, outer_id = None):
        url = API_HOST + "faceset/addface"
        params = self.url_params

        if not faceset_token and not outer_id:
            raise AttributeError('Missing faceset_token or outer_id argument. At least one must be set.')

        if face_tokens:
            if isinstance(face_tokens, list):
                if len(face_tokens) < 5:
                    params.update({'face_tokens': ",".join(face_tokens)})
                else:
                    raise AttributeError('face_tokens array must be length at most 5.')
            elif isinstance(face_tokens, str):
                params.update({'face_tokens': face_tokens})
            else:
                raise AttributeError('face_tokens should be a string or a list of string. You provided a ' + type(face_tokens).__name__ + 'instead.')

        if outer_id:
            params.update({'outer_id': outer_id})
        elif faceset_token:
            params.update({'faceset_token': faceset_token})
        else:
            raise AttributeError('You must define a unique outer_id or face_token.')

        return self._sendRequest(url, params = params)

    def deleteFaceSet(self, outer_id = None, faceset_token = None ):
        url = API_HOST + 'faceset/delete'
        params = self.url_params

        if outer_id:
            params.update({'outer_id': outer_id})
        elif faceset_token:
            params.update({'faceset_token': faceset_token})
        else:
            raise AttributeError('You must define a unique outer_id or face_token.')

        return self._sendRequest(url, params = params)

    def createFaceSet(self, display_name = None, outer_id = None, face_tokens = None ):
        url = API_HOST + 'faceset/create'
        params = self.url_params

        if not outer_id or not isinstance(outer_id, str):
            raise AttributeError('You must define a unique outer_id')
        params.update({'outer_id': outer_id})

        if display_name:
            params.update({'display_name': display_name})

        if face_tokens:
            if isinstance(face_tokens, list):
                if len(face_tokens) <= 5:
                    params.update({'face_tokens': ",".join(face_tokens)})
                else:
                    raise AttributeError('face_tokens array must be length at most 5.')
            elif isinstance(face_tokens, str):
                params.update({'face_tokens': face_tokens})
            else:
                raise AttributeError('face_tokens should be a string or a list of string. You provided a ' + type(face_tokens).__name__ + 'instead.')

        return self._sendRequest(url, params = params)

    def getFaceSetDetail(self, outer_id = None, faceset_token = None, start = 1):
        url = API_HOST + 'faceset/getdetail'
        params = self.url_params

        if not outer_id and not faceset_token:
            raise AttributeError('You must define a unique outer_id or faceset_token.')
        if outer_id and faceset_token:
            raise AttributeError('You must define only one between outer_id and faceset_token.')

        if isinstance(outer_id, str):
            params.update({'outer_id': outer_id})
        elif not outer_id is None:
            raise AttributeError('tags should be a str. You provided a ' + type(outer_id).__name__ + ' instead.')

        if isinstance(faceset_token, str):
            params.update({'faceset_token': faceset_token})
        elif not faceset_token is None:
            raise AttributeError('tags should be a str. You provided a ' + type(faceset_token).__name__ + ' instead.')

        if not isinstance(start, int):
            raise AttributeError('start should be a int. You provided a ' + type(start).__name__ + ' instead.')
        elif start < 1 or start > 10000:
            raise AttributeError('start must be between 1 and 10.000 .')
        else:
            params.update({'start': start})

        return self._sendRequest(url, params = params)

    def getFaceSets(self, tags = None, start = 1):
        url = API_HOST + 'faceset/getfacesets'
        params = self.url_params

        if isinstance(tags, str):
            params.update({'tags': tags})
        elif not tags is None:
            raise AttributeError('tags should be a str. You provided a ' + type(tags).__name__ + ' instead.')

        if not isinstance(start, int):
            raise AttributeError('start should be a int. You provided a ' + type(start).__name__ + ' instead.')
        elif start < 1:
            raise AttributeError('start must be at least one.')
        else:
            params.update({'start': start})

        return self._sendRequest(url, params = params)

    def updateFaceSet(self, outer_id = None, faceset_token = None, new_outer_id=None, display_name=None, user_data=None, tags=None):

        url = API_HOST + 'faceset/update'
        params = self.url_params

        if not outer_id and not faceset_token:
            raise AttributeError('You must define a unique outer_id or faceset_token.')

        if outer_id and isinstance(outer_id, str):
            params.update({'outer_id': outer_id})
        else:
            raise AttributeError('outer_id should be a str. You provided a ' + type(outer_id).__name__ + 'instead.')

        if faceset_token and isinstance(faceset_token, str):
            params.update({'faceset_token': faceset_token})
        else:
            raise AttributeError('faceset_token should be a str. You provided a ' + type(faceset_token).__name__ + 'instead.')

        if not new_outer_id and not display_name and not user_data and not tags:
            raise AttributeError('You must define at least one of the following params: new_outer_id, display_name, user_data, user_data')

        if new_outer_id and isinstance(new_outer_id, str):
            params.update({'new_outer_id': new_outer_id})
        else:
            raise AttributeError('new_outer_id should be a str. You provided a ' + type(new_outer_id).__name__ + 'instead.')

        if display_name and isinstance(display_name, str):
            params.update({'display_name': display_name})
        else:
            raise AttributeError('display_name should be a str. You provided a ' + type(display_name).__name__ + 'instead.')

        if user_data and isinstance(user_data, str):
            params.update({'user_data': user_data})
        else:
            raise AttributeError('user_data should be a str. You provided a ' + type(user_data).__name__ + 'instead.')

        if tags and isinstance(tags, str):
            params.update({'tags': user_data})
        else:
            raise AttributeError('tags should be a str. You provided a ' + type(tags).__name__ + 'instead.')

        return self._sendRequest(url, params = params)
