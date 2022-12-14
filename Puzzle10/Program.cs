var text = System.IO.File.ReadAllLines("day10.txt");

var cycles = new List<int>();
var x = 1;
cycles.Add(0);//lets start at 1
cycles.Add(x); //cycle 1
foreach (var line in text)
{
    var command = line.Split(" ");
    if (command[0] == "addx")
    {
        cycles.Add(x);
        x += int.Parse(command[1]);
        cycles.Add(x);
    }
    else
    {
        cycles.Add(x);
    }
}


var signal = cycles[20]*20 + cycles[60] * 60 + cycles[100] * 100 + cycles[140] * 140 + cycles[180] * 180 + cycles[220] * 220;

Console.WriteLine($"p1: {signal}");

Console.WriteLine("P2:");

for (int i = 1; i < cycles.Count; i++)
{
    x = cycles[i];
    var column = (i-1) % 40;
    if (x - 1 <= column && x + 1 >= column)
    {
        Console.Write("#");
    }
    else
    {
        Console.Write(".");
    }
    
    if(column == 39)
        Console.WriteLine();
}
