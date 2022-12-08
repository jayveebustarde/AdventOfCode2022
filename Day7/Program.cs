string[] input = File.ReadAllLines("C:\\Code\\AdventOfCode2022\\Day7\\input");

List<string> nav = new();                   // create List<string> that will hold the current active path (each item in list is folder name)
Dictionary<string, int> dict = new();       // crate key value pair for each path with running int value as total filesize count

for (int i = 0; i < input.Length; i++)
{
    string path = string.Join("/", nav);
    if (input[i].Contains("$ cd .."))
    {
        nav.RemoveAt(nav.Count - 1);        // remove last item from list when going back to parent folder
    }
    else if(input[i].Contains("$ cd"))      // $ cd will add the current folder to the list
    {
        nav.Add(input[i][5..]);
        path = string.Join("/", nav);
        if (!dict.ContainsKey(path))
        {
            dict.Add(path, 0);
        }
    }
    else if (input[i] != "$ ls" && !input[i].Contains("dir ")) // disregard commands ls and dir
    {
        var file = input[i].Split(' ');
        dict[path] += int.Parse(file[0]);   // add filsesize to dictionary value
    }
}

foreach(var d in dict)
{
    dict[d.Key] += dict.Where(x => x.Key != d.Key && x.Key.Contains(d.Key)).Sum(x => x.Value); 
}

var part1 = dict.Where(x => x.Value <= 100000).Sum(x => x.Value);
var part2 = dict.Where(x => x.Value >= (dict["/"] - 40000000)).OrderBy(x => x.Value).First().Value;
Console.WriteLine();