from helpers import Helpers
        
class Set:
    def __init__(self, dice: dict[str,int]):
        self.dice = dice
    
    def test(color, amount):
        return 

class Game:
    def __init__(self, id, setString):
        self.id = id
        self.sets = self.readSets(setString)

    def readSets(self,setString: str) -> list[Set]:
        sets = list()
        sSplit = setString.split(";")

        for s in sSplit:
            dSplit = s.split(',')
            dice = dict()
            for d in dSplit:
                vSplit = d.strip().split(" ")
                dice.update({vSplit[1] : int(vSplit[0])})
            sets.append(Set(dice))
        
        return sets
    
    def getPower(self) -> int:
        tracker = dict()
        for s in self.sets:
            for d in s.dice:
                if(not d in tracker or tracker[d] < s.dice[d]):
                    tracker[d] = s.dice[d]
        
        power = 1
        for t in tracker:
            power *= tracker[t]
        
        return power
            
            

class Solver:

    testSet = {"red" : 12, "green" : 13, "blue" : 14}
    games = list[Game]

    def Reader(self, line: str) -> Game:
        gSplit = line.split(":")
        header = gSplit[0].split(" ")
        id = header[len(header)-1]
        
        return Game(id, gSplit[1])

    def testGame(self,game: Game) -> bool:
        for s in game.sets:
            for d in s.dice:
                if d in self.testSet and self.testSet[d] < s.dice[d]:
                    return False
            
        return True


    def GetAnswer(self,lines,problem):
        count = 0
        for l in lines:
            game = self.Reader(l)
            if(problem == 1 and self.testGame(game)):
                count += int(game.id)
            elif(problem ==2):
                count += game.getPower()
        return str(count)



Helpers.RunSolver(Solver(),2)