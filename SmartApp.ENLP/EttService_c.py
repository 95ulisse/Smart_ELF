import sys
from interface_tags import PATH_TO_KB_MODULE, TAG_ANSWER, TAG_ELF_EMOTION, TAG_COLORED_ANSWER
sys.path.insert(0, PATH_TO_KB_MODULE)
import kb
from ett import prepare_answer
import logging

class EttService:

    def __init__(self, kb_ID, logging_lvl):
        self.logging_lvl = logging_lvl
        self.kb_ID = kb_ID
        #logging.basicConfig(stream=sys.stderr, level=logging_lvl)
        logging.info('\tETT Service started')

    def read_from_KB(pattern):
        """
        Read a tuple from the KB
        """
        # needed to query kb for tuples on which assess ELF's emotion for the answer
        return

    def write_to_KB(self, fact, tag):
        """
        Post a tuple to the KB
        """
        kb.addFact(self.kb_ID, tag, 1, 100, False, fact)
        return

    def add_emotion(self, *param):
        """
        Offers the service of eTT, consisting in manipulating an answer
        to the user in order to transform it with respect to some emotion
        extrapolated by ELF internal state (tuples)
        """
        answer = param[0][0]["$input"]
        logging.info("\tcallback ett called")
        a_fact, e_fact = prepare_answer(answer)
        self.write_to_KB(a_fact, TAG_COLORED_ANSWER)
        self.write_to_KB(e_fact, TAG_ELF_EMOTION)

    def start(self):
        """Subscribe and wait for data"""
        kb.subscribe(self.kb_ID, {"TAG":TAG_ANSWER, "text": "$input"}, self.add_emotion) # from the 'gnlp' module


if __name__ == "__main__":
    global myID
    myID = kb.register()
    ett = EttService(myID,logging_lvl=logging.DEBUG)
    ett.start()
