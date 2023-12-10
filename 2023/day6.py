from helpers import Helpers            

class Solver:

    def GetAnswer(self,lines,problem):
        solution = 1

        if problem == 2:
            lines[0] = lines[0].replace(" ","")
            lines[1] = lines[1].replace(" ","")

        times = list(map(int, lines[0].split(":")[1].strip().split()))
        distances = list(map(int, lines[1].split(":")[1].strip().split()))


        for i in range(0,len(times)):
            count = 0
            for j in range(0,times[i]):
                distance = j*(times[i]-j)
                if(distance > distances[i]):
                    count += 1
            solution *= count


        return str(solution)



Helpers.RunSolver(Solver(),6)