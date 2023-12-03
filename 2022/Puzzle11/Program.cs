using Puzzle11;

var text = System.IO.File.ReadAllLines("day11.txt");
var rounds = 10000;

var monkeys = new List<Monkey>();

for (int i = 0; i < text.Length; i+=7)
{
    monkeys.Add(new Monkey(text[i + 1], text[i+2], text[i+3], text[i+4], text[i+5]));
}

var commonNum = 1;
foreach (var monkey in monkeys)
{
    monkey.SetMonkeys(monkeys);
    commonNum *= monkey.DivBy;
}

for (int i = 0; i < rounds; i++)
{
    foreach (var monkey in monkeys)
    {
        monkey.PerformTests(false, commonNum);
    }
}

var monkeyBusiness = monkeys.OrderByDescending(m => m.inspected).Take(2).Select(m => m.inspected).ToArray();
Console.WriteLine($"Monkey Business: {monkeyBusiness[0]* monkeyBusiness[1]}");