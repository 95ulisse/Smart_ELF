"""
This file lists a certain number of query
queries are grouped by "topic"
lists are lists of tuple (ID,query)
associated to each query t

"""

"""queries with professor as last word"""
query_prof = [
    (1, "Dove posso trovare la lezione del Professor"),
    (2, "Dov'è la lezione del Professor"),
    (3, "Dove fa lezione il Professor"),
    (4, "In che aula è la lezione del Professor"),
    (5, "Dimmi l'aula della lezione del Professor"),
    (6, "Dove devo andare per seguire la lezione del Professor"),
    (7, "A che ora inizia la lezione del Professor"),
    (8, "Sono in tempo per la lezione del Professor"),
    (9, "A che ora finisce la lezione del Professor"),
    (10, "Quando inizia la lezione del Professor"),
    (11, "Quando farà lezione il Professor"),
    (12, "Quando sarà la prossima lezione del professore"),
    (13, "A che ora fa lezione il professor"),
    (14, "In che giorno è la prossima lezione del professor"),
    (15, "In che giorno fa lezione il professor"),
    (16, "In che giorno ed a che ora è la prossima lezione del professor"),
    (17, "Qual’è l’orario settimanale del professor"),
    (18, "Qual’è l’orario settimanale delle lezioni del professor"),
    (19, "Quali sono le lezioni del professor"),
    (20, "In quale dipartimento fa ricevimento il professor"),
    (21, "Dove è il ricevimento del professor"),
    (22, "A che ora è il ricevimento del professor"),
    (23, "Quando è il ricevimento del professor"),
    (24, "In quale dipartimento è lo studio del professor"),
    (25, "Qual’è lo studio del professor"),
    (26, "Qual’è il numero dello studio del professor"),
    (27, "Dove è lo studio del professor"),
    (28, "Dove si trova la Lezione del Professor"),
    ]

jsonq_room = {}
jsonq_room["_data"] = {}
jsonq_room["_data"]["subject"] = "<professor>"
jsonq_room["_data"]["relation"] = "<relation>"
jsonq_room["_data"]["object"] = "$Y"


query_prof_t = [
    (1, jsonq_room, "La lezione del professor <professor> è in <room>"),
    (2, jsonq_room, "La lezione del professor <professor> è in <room>"),
    (3, {"_data":{"subject":"<professor>", "relation":"teach","object":"$Y"}}, "La lezione del professor <professor> è in <room>"),
    (4, {"_data":{"subject":"<professor>", "relation":"teach","object":"$Y"}}, "Il <professor> fa lezione in <room>"),
    (5, {"_data":{"subject":"<professor>", "relation":"teach","object":"$Y"}}, "Il <professor> fa lezione in <room>"),
    (6, {"_data":{"subject":"<professor>", "relation":"teach","object":"$Y"}}, "Il <professor> fa lezione in <room>"),
    (7, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La lezione del professor <professor> inizia alle <time>"),
    (8, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La lezione del professor <professor> inizia alle <time>"),
    (9, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La lezione del professor <professor> è alle <time>"),
    (10, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La lezione del professor <professor> inizia alle <time>"),
    (11, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La lezione del professor <professor> inizia alle <time>"),
    (12, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La lezione del professor <professor> inizia alle <time>"),
    (13, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La lezione del professor <professor> inizia alle <time>"),
    (14, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La prossima lezione del professor <professor> è prevista per <time>"),
    (15, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La lezione del professor <professor> è il giorno <time>"),
    (16, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La prossima lezione del professor <professor> è prevista per <time> alle <time>"),
    (16, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La prossima lezione del professor <professor> è prevista per <time> alle <time>"),
    (17, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "Il professor <professor> ha lezione <time>"),
    (18, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "Il professor <professor> ha lezione <time>"),
    (19, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "Il professor <professor> insegna i corsi di <course>"),
    (20, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "Il professor <professor> riceve al dipartimento di <department>"),
    (21, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "Il professor <professor> riceve nel suo studio <location>"),
    (22, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "Il professore <professor> riceve alle <time> il giorno <time>"),
    (23, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "Il professore <professor> riceve alle <time> il giorno <time>"),
    (24, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "Il professor <professor> riceve al dipartimento di <department>"),
    (25, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "Il professor <professor> riceve al dipartimento di <department> stanza <room>"),
    (26, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "Il professor <professor> riceve al dipartimento di <department> stanza <room>"),
    (27, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "Il professor <professor> riceve al dipartimento di <department>"),
    (28, {"_data":{"subject":"<professor>", "relation":"teach","object":"time"}}, "La lezione del professor <professor> è in <room>")
    ]