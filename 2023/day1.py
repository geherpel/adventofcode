from helpers import Helpers

class Solver: 
    mapper = {"one" : 1,
            "two" : 2,
            "three" : 3,
            "four" : 4,
            "five" : 5,
            "six" : 6,
            "seven" : 7,
            "eight" : 8,
            "nine" : 9
            }

    def IsIntWord(self,word, reversed) -> int:
        ret = -1
        for key in self.mapper.keys():
            k = key[::-1] if reversed else key
            if k in word:
                return self.mapper[key]
        return -1

    def checkForFirstNum(self, line, problem, reversed = False) -> str:
        rStr = ""
        for c in line:
            if c.isnumeric():
                return c
            elif problem == 2:
                rStr += c
                ret = self.IsIntWord(rStr, reversed)
                if(ret > -1):
                    return str(ret)

    def GetAnswer(self,lines,problem) -> int:
        count = 0
        for l in lines:
            count += int(self.checkForFirstNum(l,problem) + self.checkForFirstNum(l[::-1], problem, True))
        return str(count)



Helpers.RunSolver(Solver(),1)