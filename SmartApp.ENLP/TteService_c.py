import sys
from interface_tags import TAG_USER_TRANSCRIPT, TAG_USER_EMOTION, PATH_TO_KB_MODULE
sys.path.insert(0, PATH_TO_KB_MODULE)
import kb
from tte import extract_emotion
from italian import *
import logging

class TteService:

    def __init__(self, kb_ID, logging_lvl):
        self.logging_lvl = logging_lvl
        self.kb_ID = kb_ID
        self.watson_auth = watson_authentication()
        #logging.basicConfig(stream=sys.stderr, level=logging_lvl)
        logging.info('\tTTE Service started')


    def read_from_KB(pattern):
        """
        Read a tuple from the KB
        """
        # not needed here
        return

    def write_to_KB(self, fact):
        """
        Post a tuple to the KB
        """

        kb.addFact(self.kb_ID, TAG_USER_EMOTION, 1, 100, False, fact)
        return

    def text_to_emotion(self, *param):
        """
        Assess user emotion from a given sentence
        """
        sentence = param[0][0]["$input"]
        lang = param[0][0]["$lang"]
        logging.info("\tcallback TTE called")
        if (lang == "it"):
            sentence = tranlsate(sentence,self.watson_auth)
        fact = extract_emotion(sentence)
        self.write_to_KB(fact)
        return

    def start(self):
        kb.subscribe(self.kb_ID, {"TAG": TAG_USER_TRANSCRIPT, "text": "$input", "language": "$lang"}, self.text_to_emotion) #from the 'text to speech' module

    if __name__ == "__main__":
        global myID
        myID = kb.register()
        tte = TteService(kb_ID, logging_lvl=logging.DEBUG)
        tte.start()