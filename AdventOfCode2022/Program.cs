string[] input = File.ReadAllLines("C:\\Code\\AdventOfCode2022\\AdventOfCode2022\\input");

var calories = new List<int>();

int counter = 0;

for (int i = 0; i < input.Length; i++)
{
    if (string.IsNullOrWhiteSpace(input[i]) || i == input.Length - 1)
    {
        calories.Add(counter);
        counter = 0;
        continue;
    }
    if (int.TryParse(input[i], out int current))
    {
        counter += current;
    }
}
Console.WriteLine(calories.Max());
Console.WriteLine(calories.OrderByDescending(x => x).Take(3).Sum());