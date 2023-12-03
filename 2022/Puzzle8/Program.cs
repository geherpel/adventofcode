var text = System.IO.File.ReadAllLines("day8.txt");

var visible = 0;
for (var i = 0; i < text.Length; i++)
{
    var line = text[i];
    for (var j = 0; j < line.Length; j++)
    {
        //we are on the edge, auto count
        if (i == 0 || j == 0 || i == text.Length - 1 || j == line.Length - 1)
        {
            visible++;
        }
        else
        {
            var visCheck = false;
            //check up
            for (var k = 0; k < i; k++)
            {
                if (text[k][j] >= line[j])
                {
                    visCheck = false;
                    break;
                }
                else
                {
                    visCheck = true;
                }
            }

            if (visCheck)
            {
                visible++;
                continue;
            }

            //check down
            for (var k = i + 1; k < text.Length; k++)
            {
                if (text[k][j] >= line[j])
                {
                    visCheck = false;
                    break;
                }
                else
                {
                    visCheck = true;
                }
            }
            if (visCheck)
            {
                visible++;
                continue;
            }

            //check left
            for (var k = 0; k < j; k++)
            {
                if (text[i][k] >= line[j])
                {
                    visCheck = false;
                    break;
                }
                else
                {
                    visCheck = true;
                }
            }
            if (visCheck)
            {
                visible++;
                continue;
            }

            //check right
            for (var k = j + 1; k < line.Length; k++)
            {
                if (text[i][k] >= line[j])
                {
                    visCheck = false;
                    break;
                }
                else
                {
                    visCheck = true;
                }
            }

            if (visCheck)
            {
                visible++;
                continue;
            }
        }
    }
}

Console.WriteLine($"p1: {visible}");


var highScore = 0;
for (var i = 1; i < text.Length-1; i++)
{
    var line = text[i];
    for (var j = 1; j < line.Length-1; j++)
    {
        var count = 0;
        var currentScore = 1;
        //check up
        for (var k = i-1; k >= 0; k--)
        {
            if (text[k][j] >= line[j])
            {
                count++;
                break;
            }
            else
            {
                count++;
            }
        }
        currentScore *= count;
        count = 0;

        //check down
        for (var k = i + 1; k < text.Length; k++)
        {
            if (text[k][j] >= line[j])
            {
                count++;
                break;
            }
            else
            {
                count++;
            }
        }
        currentScore *= count;
        count = 0;

        //check left
        for (var k = j-1; k >= 0; k--)
        {
            if (text[i][k] >= line[j])
            {
                count++;
                break;
            }
            else
            {
                count++;
            }
        }
        currentScore *= count;
        count = 0;

        //check right
        for (var k = j + 1; k < line.Length; k++)
        {
            if (text[i][k] >= line[j])
            {
                count++;
                break;
            }
            else
            {
                count++;
            }
        }
        currentScore *= count;
        count = 0;

        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
    }
}

Console.WriteLine($"p2: {highScore}");