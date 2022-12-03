using Puzzle3;

var text = System.IO.File.ReadAllLines("day3.txt");

var total = 0;

foreach (var line in text)
{
    var left = line.Substring(0, line.Length / 2);
    var right = line.Substring(line.Length / 2);
    
    foreach (var item in left)
    {
        if (right.Contains(item))
        {
            total += (int)((Helper.alphabet)Enum.Parse(typeof(Helper.alphabet), item.ToString()))+1;
            break;
        }
    }
}

Console.WriteLine($"p1: {total}");

total = 0;
for(int i = 0; i < text.Length; i++)
{
    var one = text[i];
    var two = text[i += 1];
    var three = text[i += 1];

    foreach (var item in one)
    {
        if (two.Contains(item) && three.Contains(item))
        {
            total += (int)((Helper.alphabet)Enum.Parse(typeof(Helper.alphabet), item.ToString())) + 1;
            break;
        }
    }
}

Console.WriteLine($"p2: {total}");