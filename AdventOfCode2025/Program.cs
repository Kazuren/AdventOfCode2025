using AdventOfCode2025.Puzzles;
using AdventOfCode2025.Puzzles.Day3Lobby;
using AdventOfCode2025.Puzzles.Day4PrintingDepartment;
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

        Trace.WriteLine($"Day 3, Part 1: {Lobby.PartOne.Run()}");
        Trace.WriteLine($"Day 3, Part 2: {Lobby.PartTwo.Run()}");

        Trace.WriteLine($"Day 4, Part 1: {PrintingDepartment.PartOne.Run()}");
        Trace.WriteLine($"Day 4, Part 2: {PrintingDepartment.PartTwo.Run()}");
    }
}

