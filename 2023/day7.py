from helpers import Helpers

class Hand:
    def __init__(self, bid, cards):
        self.bid = bid
        self.cards = cards
        self.kind = 1
        self.addPair = 0

class Solver:

    mapper = {"2" : 1,
            "3" : 2,
            "4" : 3,
            "5" : 4,
            "6" : 5,
            "7" : 6,
            "8" : 7,
            "9" : 8,
            "T" : 9,
            "J" : 0,
            "Q" : 11,
            "K" : 12,
            "A" : 13
            }

    def compareCards(self, c):
        return self.mapper[c]
                
    def compHands(self, h):
        val = h.kind * pow(10,13)
        val += h.addPair * pow(10,12)
        for i in range (0, 5):
            val += self.mapper[h.cards[i]] * pow(10,(10-(2*i)))
        h.val = val
        return val

    def GetAnswer(self,lines,problem):
        hands = []

        for l in lines:
            h = l.split()
            cards = list(h[0])
            hand = Hand(int(h[1]), cards.copy())
            cards.sort(key=self.compareCards,reverse=True)

            running = 1
            card = "0"
            wilds = cards.count("J")
            wilds = 4 if wilds > 4 else wilds
            for i in range(0,4):
                if cards[i] == cards[i+1] and cards[i] != "J":
                    running += 1
                    if(hand.kind < running):
                        hand.kind = running
                        card = cards[i]
                else:
                    running = 1

            if(card != "J"):
                hand.kind += wilds
            
            if(card != "0"):
                running = 1
                for i in range(0,4):
                    if cards[i] == cards[i+1] and cards[i] != card and cards[i] != "J":
                        hand.addPair = 1

            hands.append(hand)

        hands.sort(key=self.compHands)

        solution = 0
        for i in range(1,len(hands)+1):
            solution += hands[i-1].bid * i

        return str(solution)



Helpers.RunSolver(Solver(),7)