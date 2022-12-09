using Puzzle9;

var text = System.IO.File.ReadAllLines("day9.txt");
var grid = new Grid(10);


foreach (var line in text)
{
    var command = line.Split(' ');
    for (int i = 0; i < int.Parse(command[1]); i++)
    {
        grid.MoveHead(command[0][0]);
    }
}
System.Console.WriteLine($"p1: {grid.TailVisited.Count()}");


static void drawMap(Grid grid)
{

    for (int y = grid.TailVisited.Max(v => v.y) + 1; y >= grid.TailVisited.Min(v => v.y) - 1; y--)
    {
        for (int x = grid.TailVisited.Min(v => v.x) - 1; x <= grid.TailVisited.Max(v => v.x) + 1; x++)
        {
            var p = new Position()
            {
                x = x,
                y = y
            };
            
            if (grid.Head.EqualPos(p))
                Console.Write(" H ");
            else if (grid.Tails.Any(t => t.EqualPos(p)))
                Console.Write(" T ");
            else if (x == 0 && y == 0)
                Console.Write(" S ");
            else if (grid.TailVisited.Exists(v => v.EqualPos(p)))
                Console.Write(" # ");
            else
                Console.Write(" . ");
        }

        Console.WriteLine();
    }
}