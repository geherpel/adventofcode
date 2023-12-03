using Microsoft.VisualBasic;

int vbObjectError = 34;


Information.Err().Raise(12);

int x = 3;
x++;x--; x++;
Console.WriteLine(x);

Console.WriteLine(Information.Err().Number);
Information.Err().Clear();
Console.WriteLine(Information.Err().Number);