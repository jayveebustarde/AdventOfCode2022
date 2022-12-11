//string[] input = File.ReadAllLines("C:\\Code\\AdventOfCode2022\\Day9\\input");
string[] input = new string[] {
"R 5",
"U 8",
"L 8",
"D 3",
"R 17",
"D 10",
"L 25",
"U 20" };
List<Tuple<int, int>> tPositions = new();
List<Tuple<int, int>[]> part2Positions = new();
var (hx, hy, tx, ty) = (0, 0, 0, 0);
for (int i = 0; i < input.Length; i++)
{
    part2Positions.Add(new Tuple<int, int>[10]);
    int move = int.Parse(input[i][2..]);
    tx = part2Positions.Last()[1]?.Item1 ?? 0;
    ty = part2Positions.Last()[1]?.Item2 ?? 0;
    if (input[i][0] == 'D')
    {
        for (int j = hy; j >= hy - move; j--)
            ComputeMove(tPositions, 0, hx, j, ref tx, ref ty);
        hy -= move;
    }
    else if (input[i][0] == 'U')
    {
        for (int j = hy; j <= hy + move; j++)
            ComputeMove(tPositions, 0, hx, j, ref tx, ref ty);
        hy += move;
    }
    else if (input[i][0] == 'L')
    {
        for (int j = hx; j >= hx - move; j--)
            ComputeMove(tPositions, 0, j, hy, ref tx, ref ty);
        hx -= move;
    }
    else if (input[i][0] == 'R')
    {
        for (int j = hx; j <= hx + move; j++)
            ComputeMove(tPositions, 0, j, hy, ref tx, ref ty);
        hx += move;
    }
}
Console.WriteLine("Part1: " + tPositions.Count);

void ComputeMove(List<Tuple<int, int>> tPositions, int index, int hx, int hy, ref int tx, ref int ty)
{
    if (Math.Abs(hx - tx) + Math.Abs(hy - ty) > 2)
    {
        tx += hx > tx ? 1 : -1;
        ty += hy > ty ? 1 : -1;
    }
    else if (Math.Abs(hx - tx) > 1 || Math.Abs(hy - ty) > 1)
    {
        tx += Math.Abs(hx - tx) > 1 ? hx > tx ? 1 : -1 : 0;
        ty += Math.Abs(hy - ty) > 1 ? hy > ty ? 1 : -1 : 0;
    }
    int tempTx = tx, tenpTy = ty;
    part2Positions.Last()[index] = new(tx, ty);
    if (index == 9)
    {
        if (!tPositions.Any(x => x.Item1 == tempTx && x.Item2 == tenpTy))
            tPositions.Add(new(tx, ty));
        return;
    }
    int newtx = 0, newty = 0;
    if(part2Positions.Count > 1)
        (newtx, newty) = part2Positions.Skip(part2Positions.Count - 1).Take(1).FirstOrDefault()[index];

    ComputeMove(tPositions, index + 1, tx, ty, ref newtx, ref newty);
}