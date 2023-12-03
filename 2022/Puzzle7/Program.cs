using Puzzle7;

var text = System.IO.File.ReadAllLines("day7.txt");

var fileSystemSize = 70000000;
var updateSize = 30000000;

var treeRoot = new Dir("/");
var current = treeRoot;

//parse dir structure
foreach (var line in text)
{
    if (line.StartsWith("$ "))
    {
        var command = line.Remove(0, 2);
        if (command.StartsWith("cd"))
        {
            var loc = command.Remove(0, 3);
            if (loc == "/")
            {
                current = treeRoot;
            }
            else if (loc == "..")
            {
                current = current.Parent;
            }
            else
            {
                current = current.Dirs.Find(x => x.Name == loc);
            }
        }
    }
    else
    {
        if (line.StartsWith("dir"))
        {
            var dirName = line.Remove(0, 4);
            current.Dirs.Add(new Dir(dirName,current));
        }
        else
        {
            var fileVals = line.Split(" ");
            current.Files.Add(new Stuff(fileVals[1], int.Parse(fileVals[0])));
        }
    }
}

Console.WriteLine($"p1: {treeRoot.ContainsLTE(100000)}");

Console.WriteLine($"p2: {treeRoot.ClosestDir(updateSize - (fileSystemSize - treeRoot.Size))}");