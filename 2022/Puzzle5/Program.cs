using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Puzzle5;

var text = System.IO.File.ReadAllLines("day5.txt");

//set up stacks

var index = 0;
var line = text[index];
var stacks = Helper.CreateStacks(line.Length/4 + 1);

var instStart = Helper.SetStacks(index, text, stacks) + 1;

var readRegex = new Regex(@"move (\d+) from (\d+) to (\d+)");

for (int i = instStart; i < text.Length; i++)
{
    var match = readRegex.Match(text[i]);
    if (match.Success)
    {
        var move = int.Parse(match.Groups[1].Value);
        var from = int.Parse(match.Groups[2].Value) - 1;
        var to = int.Parse(match.Groups[3].Value) - 1;

        //p1
        /*
        for (int j = 0; j < move; j++)
        {
            var crate = stacks[from].Pop();
            stacks[to].Push(crate);
        }
        */

        //p2
        var crates = new Stack<char>();
        for (int j = 0; j < move; j++)
        {
            crates.Push(stacks[from].Pop());
        }

        while (crates.Count > 0)
        {
            stacks[to].Push(crates.Pop());
        }
    }
}

var output = string.Empty;
foreach (var stack in stacks)
{
   output += stack.Pop();
}

Console.WriteLine($"{output}");
