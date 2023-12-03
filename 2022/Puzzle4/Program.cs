var text = System.IO.File.ReadAllLines("day4.txt");

var count = 0;
foreach (var line in text)
{
    var pairs = line.Split(',');
    var rangeOne = pairs[0].Split("-");
    var oneLow = int.Parse(rangeOne[0]);
    var oneHigh = int.Parse(rangeOne[1]);
    var rangeTwo = pairs[1].Split("-");
    var twoLow = int.Parse(rangeTwo[0]);
    var twoHigh = int.Parse(rangeTwo[1]);

    if ((oneLow <= twoLow && oneHigh >= twoHigh) || (twoLow <= oneLow && twoHigh >= oneHigh))
    {
        count++;
    }
}

Console.WriteLine($"p1: {count}");

count = 0;
foreach (var line in text)
{
    var pairs = line.Split(',');
    var rangeOne = pairs[0].Split("-");
    var oneLow = int.Parse(rangeOne[0]);
    var oneHigh = int.Parse(rangeOne[1]);
    var rangeTwo = pairs[1].Split("-");
    var twoLow = int.Parse(rangeTwo[0]);
    var twoHigh = int.Parse(rangeTwo[1]);

    if ((oneLow >= twoLow && oneLow <= twoHigh) || (twoLow >= oneLow && twoLow <= oneHigh) ||
        (oneHigh >= twoLow && oneHigh <= twoHigh) || (twoHigh >= oneLow && twoHigh <= oneHigh))
    {
        count++;
    }
}

Console.WriteLine($"p2: {count}");