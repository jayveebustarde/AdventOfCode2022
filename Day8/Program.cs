string[] input = File.ReadAllLines("C:\\Code\\AdventOfCode2022\\Day8\\input");
int visibleCount = 0;
long maxView = 0;
for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        bool l, r, t, b;
        l = r = t = b = true;
        long lv, tv, bv, rv;
        lv = tv = bv = rv = 0;
        if (i == 0 || i == input.Length - 1 || j == 0 || j == input[i].Length - 1)
        {
            visibleCount++;
            continue;
        }
        for (int top = i - 1; top > -1; top--)
        {
            if (t)
            {
                tv++;
                t = input[top][j] < input[i][j];
            }
        }
        for (int left = j - 1; left > -1; left--)
        {
            if (l)
            {
                lv++;
                l = input[i][left] < input[i][j];
            }
        }
        for (int bottom = i + 1; bottom < input.Length; bottom++)
        {
            if (b)
            {
                bv++;
                b = input[bottom][j] < input[i][j];
            }
        }
        for (int right = j + 1; right < input[i].Length; right++)
        {
            if (r)
            {
                rv++;
                r = input[i][right] < input[i][j];
            }
        }
        visibleCount += (l || r || t || b) ? 1 : 0;
        long total = tv * rv * bv * lv;
        maxView = total > maxView ? total : maxView;
    }
}

Console.WriteLine(visibleCount);
Console.WriteLine(maxView);