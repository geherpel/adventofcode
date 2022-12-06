var text = System.IO.File.ReadAllLines("day6.txt");

var chars = string.Empty;
var lineCount = 0;
foreach (var line in text)
{
    lineCount++;
    for (int i = 0; i < line.Length; i++)
    {
        var c = line[i];
        if (chars.Contains(c))
        {
            chars = chars.Substring(chars.IndexOf(c) + 1) + c;
        }
        else
        {
            chars += c;
        }

        if (chars.Length >= 14)
        {
            Console.WriteLine($"line {lineCount}: {i+1} : {chars}");
            break;
        }
    }
}