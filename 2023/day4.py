from helpers import Helpers            

class Solver:

    

    def GetAnswer(self,lines,problem):
        count = 0
        cards = list()

        for l in lines:
            header = l.split(":")
            numHeader = header[0].split(" ")
            cardNum = int(numHeader[len(numHeader)-1])
            card = header[1].split("|")
            wNums = card[0].strip().split(" ")
            while "" in wNums : wNums.remove("")
            nums = card[1].strip().split(" ")
            while "" in nums : nums.remove("")
            points = 0
            wins = 0

            cards.append(cardNum)
            cardCount = cards.count(cardNum)

            for w in wNums:
                if w in nums:
                    if(problem == 1):
                        points = 1 if points == 0 else points * 2
                        continue
                    if(problem == 2):
                        wins += 1
                        continue

            i = 1
            j = 0
            while i <= wins and j < cardCount and cardNum + i <= len(lines):
                cards.append(cardNum + i)
                j += 1
                if(j == cardCount):
                    j = 0
                    i += 1

            if(problem == 2):
                count += cardCount
            else:
                count += points

        return str(count)



Helpers.RunSolver(Solver(),4)