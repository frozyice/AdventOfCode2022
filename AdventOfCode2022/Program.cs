using System.Diagnostics;
using AdventOfCode2022;

var day = new Day08();
var stopwatch = new Stopwatch();

Console.WriteLine("Part One");
stopwatch.Start();
Console.WriteLine(day.PartOne());
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);
Console.WriteLine();

Console.WriteLine("Part Two");
stopwatch.Restart();
Console.WriteLine(day.PartTwo());
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);

