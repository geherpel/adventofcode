from helpers import Helpers

class Solver:

    def symbolAdjacent(self,i,j,lines: str) -> list[tuple]:
         ret = list()
         x = i - 1
         while x <= i + 1:
            y = j - 1
            while y <= j + 1:
                if x > 0 and x < len(lines) and y > 0 and y < len(lines[x]) and not lines[x][y].isnumeric() and not lines[x][y] == ".":
                    ret.append((x,y,lines[x][y]))
                y += 1
            x+=1
         return ret
            
              

    def GetAnswer(self,lines:str,problem):
        gearRatio = dict()
        count = 0
        number = 0
        gearAdjacent = list()
        adjacent = False
        i=0

        while i < len(lines):
            j=0
            while j < len(lines[i]) :
                c = lines[i][j]
                if c.isnumeric():
                    number = number*10 + int(c)
                    symbolCheck = self.symbolAdjacent(i,j,lines)
                    if not symbolCheck is None and len(symbolCheck) > 0:
                        for s in symbolCheck:
                            if s[2] == "*" and not (s[0],s[1]) in gearAdjacent:
                                gearAdjacent.append((s[0],s[1]))
                        adjacent = True
                elif adjacent:
                    if(len(gearAdjacent)>0):
                        for ga in gearAdjacent:
                            if ga in gearRatio:
                                gearRatio[ga][0] *= number
                                gearRatio[ga][1] += 1
                            else:
                                gearRatio[ga] = [number, 1]
                        gearAdjacent = list()
                    count += number
                    adjacent = False
                    number = 0
                else:
                     number = 0
                j+=1

            if adjacent:
                    if(len(gearAdjacent)>0):
                        for ga in gearAdjacent:
                            if ga in gearRatio:
                                gearRatio[ga][0] *= number
                                gearRatio[ga][1] += 1
                            else:
                                gearRatio[ga] = [number, 1]
                        gearAdjacent = list()
                    count += number
                    adjacent = False
            number = 0

            i+=1
        if problem == 2:
            count = 0
            for r in gearRatio:
                if(gearRatio[r][1] > 1):
                    count += gearRatio[r][0]
        return str(count)



Helpers.RunSolver(Solver(),3)