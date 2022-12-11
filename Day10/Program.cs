string[] input = File.ReadAllLines("C:\\Code\\AdventOfCode2022\\Day10\\input");
string[] input_ = new string[]
{
"addx 15",
"addx -11",
"addx 6",
"addx -3",
"addx 5",
"addx -1",
"addx -8",
"addx 13",
"addx 4",
"noop",
"addx -1",
"addx 5",
"addx -1",
"addx 5",
"addx -1",
"addx 5",
"addx -1",
"addx 5",
"addx -1",
"addx -35",
"addx 1",
"addx 24",
"addx -19",
"addx 1",
"addx 16",
"addx -11",
"noop",
"noop",
"addx 21",
"addx -15",
"noop",
"noop",
"addx -3",
"addx 9",
"addx 1",
"addx -3",
"addx 8",
"addx 1",
"addx 5",
"noop",
"noop",
"noop",
"noop",
"noop",
"addx -36",
"noop",
"addx 1",
"addx 7",
"noop",
"noop",
"noop",
"addx 2",
"addx 6",
"noop",
"noop",
"noop",
"noop",
"noop",
"addx 1",
"noop",
"noop",
"addx 7",
"addx 1",
"noop",
"addx -13",
"addx 13",
"addx 7",
"noop",
"addx 1",
"addx -33",
"noop",
"noop",
"noop",
"addx 2",
"noop",
"noop",
"noop",
"addx 8",
"noop",
"addx -1",
"addx 2",
"addx 1",
"noop",
"addx 17",
"addx -9",
"addx 1",
"addx 1",
"addx -3",
"addx 11",
"noop",
"noop",
"addx 1",
"noop",
"addx 1",
"noop",
"noop",
"addx -13",
"addx -19",
"addx 1",
"addx 3",
"addx 26",
"addx -30",
"addx 12",
"addx -1",
"addx 3",
"addx 1",
"noop",
"noop",
"noop",
"addx -9",   //
"addx 18",
"addx 1",
"addx 2",
"noop",
"noop",
"addx 9",
"noop",
"noop",
"noop",
"addx -1",
"addx 2",
"addx -37",
"addx 1",
"addx 3",
"noop",
"addx 15",
"addx -21",
"addx 22",
"addx -6",
"addx 1",
"noop",
"addx 2",
"addx 1",
"noop",
"addx -10",
"noop",
"noop",
"addx 20",
"addx 1",
"addx 2",
"addx 2",
"addx -6",
"addx -11",
"noop",
"noop",
"noop"
};

int[] signals = new int[] { 20, 60, 100, 140, 180, 220 };
int x = 1;
int cycle = 1;
int totalStrength = 0;
string crtRow = "";
for (int i = 0; i < input.Length; i++)
{
    if (input[i] == "noop")
        processCycle();
    if (input[i][..4] == "addx")
    {
        processCycle();
        processCycle();
        int y = int.Parse(input[i][5..]);
        x += y;
    }
}
void processCycle()
{
    if (signals.Contains(cycle))
        totalStrength += cycle * x;
    crtRow += Math.Abs((cycle % 40) - (x + 1)) > 1 ? "." : "#";
    if (cycle % 40 == 0)
    {
        Console.WriteLine((crtRow) + " " + crtRow.Length);
        crtRow = "";
    }
    cycle++;
}

Console.WriteLine(totalStrength);