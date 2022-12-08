// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string input = File.ReadAllText("C:\\Code\\AdventOfCode2022\\Day6\\input");


for(int i = 0; i < input.Length; i++)
{
    string iter = input.Substring(i, 14);
    if(iter.ToCharArray().Distinct().Count() > 13)
    {
        Console.WriteLine(i + 14);
        break;
    }
}
