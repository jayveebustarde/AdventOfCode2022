//string[] input = File.ReadAllLines("C:\\Code\\AdventOfCode2022\\Day9\\input");
string[] input = new string[]
{
"R 4",
"U 4",
"L 3",
"D 1",
"R 4",
"D 1",
"L 5",
"R 2"
};

List<Tuple<int, int>> tPositions = new();
var (hx, hy, tx, ty) = (0, 0, 0, 0);
for (int i = 0; i < input.Length; i++)
{
    int move = int.Parse(input[i][2..]);

    if (input[i][0] == 'D')
    {
        for (int j = hy; j >= hy - move; j--)
        {
            ComputeMove(tPositions, move, hx, hy, ref tx, ref ty);
        }
        hy -= move;
    }
    else if (input[i][0] == 'U')
    {
        for (int j = ty; j <= ty + move; j++)
        {
            ComputeMove(tPositions, move, hx, hy, ref tx, ref ty);
        }
        hy += move;
    }
    if (input[i][0] == 'L')
    {
        for (int j = tx; j >= tx - move; j--)
        {
            ComputeMove(tPositions, move, hx, hy, ref tx, ref ty);
        }
        tx -= move;
    }
    else if (input[i][0] == 'R')
    {
        for (int j = tx; j <= tx + move; j++)
        {
            ComputeMove(tPositions, move, hx, hy, ref tx, ref ty);
        }
        tx += move;
    }
}
Console.WriteLine(tPositions.Count);

void ComputeMove(List<Tuple<int, int>> tPositions, int move, int hx, int hy, ref int tx, ref int ty)
{
    if (Math.Abs(hx - tx) > 1 || Math.Abs(hy - ty) > 1)
    {
        tx += Math.Abs(hx - tx) > 1 ? (hx > tx) ? 1 : -1 : 0;
        ty += Math.Abs(hy - ty) > 1 ? (hy > ty) ? 1 : -1 : 0;
        int tempTx = tx, tenpTy = ty;
        if (!tPositions.Any(x => x.Item1 == tempTx && x.Item2 == tenpTy))
            tPositions.Add(new(tx, ty));
    }
}
