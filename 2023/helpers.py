import os

class DayFile:
    def __init__(self, fileName, problems):
        self.fileName = fileName
        self.problems = problems

class Helpers:

    # Get the file input as a list of rows
    @staticmethod
    def getFileContentAsList(file,filePath) -> list[str]:
        with open(os.path.join(filePath,file)) as inputFile: # open file
            content = inputFile.read() # read full content
            inputFile.close()
            # Split on new line and insert each frow in list
            inputList = [ x for x in content.split("\n") if x != '' ]
            return inputList
    
    @staticmethod
    def genFiles(filePath, day) -> DayFile:
        files = [DayFile("day%s-ex.txt"%day,[1,2]),
                 DayFile("day%s-ex1.txt"%day,[1]),
                 DayFile("day%s-ex2.txt"%day,[2]),
                 DayFile("day%s.txt"%day,[1,2]),
                 DayFile("day%s-1.txt"%day,[1]),
                 DayFile("day%s-2.txt"%day,[2])]
        ret = []

        for file in files:
            if(os.path.isfile(os.path.join(filePath,file.fileName))):
                ret.append(file)

        return ret
        
    @staticmethod
    def RunSolver(solver, day, files = None, filePath = "2023/inputs"):
        if files == None:
            files = Helpers.genFiles(filePath, day)
        
        for file in files:
            for problem in file.problems:
                content = Helpers.getFileContentAsList(file.fileName, filePath)
                answer = solver.GetAnswer(content, problem)
                print("%s problem %s: %s"% (file.fileName,str(problem),answer))
