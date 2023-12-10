import re
from helpers import Helpers

class Map:
    def __init__(self, source, target,range):
        self.source = source
        self.target = target
        self.range = range

class Mapper:

    def __init__(self, source, target):
        self.source = source
        self.target = target
        self.maps = list()

    def EvalMap(self, value):
        for m in self.maps:
            if value >= m.source and value <= m.source + m.range - 1:
                return m.target + (value - m.source)
        return value

class Solver:

    def Evaluate(self, source, value, mappers):     
        for m  in [x for x in mappers if x.source == source]:
            return self.Evaluate(m.target,m.EvalMap(value),mappers)
        return value

    def GetAnswer(self,lines,problem):
        count = 0
        mappers = list()

        seeds = [int(val) for val in lines[0].split(":")[1].strip().split(" ")]
        for l in lines:
            if "-to-" in l:
                mapping = l.split(" ")[0].split("-to-")
                mappers.append(Mapper(mapping[0],mapping[1]))
            elif(re.match("\d+ \d+ \d+",l)):
                nums = l.strip().split(" ")
                mappers[len(mappers)-1].maps.append(Map(int(nums[1]),int(nums[0]),int(nums[2])))

        min = 0
        if problem == 1:
            for s in seeds:
                ev = self.Evaluate("seed",s,mappers)
                if min == 0 or ev < min:
                    min = ev
        elif problem == 2:           
            for index in [index for index in range(len(seeds)) if index % 2 == 0]:
                for s in range(seeds[index],seeds[index] + seeds[index+1]):
                    ev = self.Evaluate("seed",s,mappers)
                    if min == 0 or ev < min:
                        min = ev

        return min

Helpers.RunSolver(Solver(),5)