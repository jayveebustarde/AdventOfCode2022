// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] input = File.ReadAllLines("C:\\Code\\AdventOfCode2022\\Day5\\input");

var entries = new List<char>[9];
for(int i = 7; i >= 0; i--)
{
    int rowcnt = 0;
    for(int j = 1; rowcnt < 9; j += 4)
    {
        if (entries[rowcnt] == null)
            entries[rowcnt] = new List<char>();
        if(input[i][j] != ' ')
            entries[rowcnt].Add(input[i][j]);
        rowcnt++;
    }
}

for(int k = 10; k < input.Length; k++)
{
    var move = int.Parse(input[k].Substring(5, input[k].IndexOf(" from") - 5));
    var from = int.Parse(input[k].Substring(input[k].IndexOf("from ") + 5, input[k].IndexOf(" to") - (input[k].IndexOf("from ") + 5))) - 1;
    var to = int.Parse(input[k].Substring(input[k].IndexOf("to ") + 3)) - 1;

    var popped = entries[from].Skip(entries[from].Count - move).Take(move);//.Reverse();
    entries[from] = entries[from].Take(entries[from].Count - move).ToList();
    entries[to].AddRange(popped);
}
string output1 = "";
for (int m = 0; m < entries.Length; m++)
{
    output1 += entries[m].LastOrDefault().ToString() ?? "";
}

Console.WriteLine(entries);