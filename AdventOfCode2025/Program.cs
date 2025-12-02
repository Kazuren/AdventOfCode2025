using AdventOfCode2025.Puzzles;
using System.Diagnostics;

namespace AdventOfCode2025;

internal class Program
{
    static void Main(string[] args)
    {

        Trace.WriteLine($"Day 1, Part 1: {SecretEntrance.PartOne.Run()}");
        Trace.WriteLine($"Day 1, Part 2: {SecretEntrance.PartTwo.Run()}");

        Trace.WriteLine($"Day 2, Part 1: {GiftShop.PartOne.Run()}");
        Trace.WriteLine($"Day 2, Part 2: {GiftShop.PartTwo.Run()}");
    }
}

