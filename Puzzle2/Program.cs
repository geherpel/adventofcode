using Puzzle2;

var text = System.IO.File.ReadAllLines("day2.txt");

var points = 0;
foreach (var line in text)
{
    var opp = Helper.MapLetters(line[0]);
    var you = Helper.MapLetters(line[2]);
    points += Helper.CalcPoints(opp, you);
}

Console.WriteLine($"pt1: {points}");

points = 0;
foreach (var line in text)
{
    var opp = Helper.MapLetters(line[0]);
    var you = Helper.MapOutcome(line[2]);
    points += Helper.CalcPoints(opp, you);
}

Console.WriteLine($"pt2: {points}");

