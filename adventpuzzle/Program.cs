var text = System.IO.File.ReadAllLines("day1.txt");

var running = 0;
var elfTotal = 1;
var elves = new Dictionary<int, int>();
foreach (var line in text)
{
    var lineAmount = 0;
    if (int.TryParse(line, out lineAmount) && lineAmount != 0)
    {
        running+=lineAmount;
    }
    else
    {
        elves.Add(elfTotal, running);
        elfTotal++;
        running = 0;
    }
}

var greatest = elves.OrderByDescending(k => k.Value).Take(1).Select(k => k.Value).Sum();
var topThree = elves.OrderByDescending(k => k.Value).Take(3).Select(k=> k.Value).Sum();

Console.WriteLine($@"Greatest: {greatest}");
Console.WriteLine($@"TOP3 Total: {topThree}");