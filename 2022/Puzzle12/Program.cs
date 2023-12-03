using Puzzle12;

var text = System.IO.File.ReadAllLines("day12.txt");



Console.WriteLine($"p1: {calcPuzzle(false)}");
Console.WriteLine($"p2: {calcPuzzle(true)}");

int calcPuzzle(bool aAsZero)
{
    var map = new Map();

    for (int i = 0; i < text.Length; i++)
    {
        var line = new List<Node>();
        for (int j = 0; j < text[i].Length; j++)
        {
            var node = new Node(text[i][j], aAsZero: aAsZero);
            line.Add(node);

            if (j > 0)
            {
                node.AddAdjacent(line[j - 1]);
                line[j - 1].AddAdjacent(node);
            }

            if (i > 0)
            {
                node.AddAdjacent(map.Grid[i - 1][j]);
                map.Grid[i - 1][j].AddAdjacent(node);
            }
        }
        map.Grid.Add(line);
        map.Nodes.AddRange(line);
    }

    var currentNode = map.Nodes.Find(n => n.Starting);

    while (!currentNode.Ending)
    {
        currentNode.CalcAdjacent();
        currentNode = map.Nodes.Where(n => !n.Visited).OrderBy(n => n.Distance).First();
    }

    return currentNode.Distance;
}