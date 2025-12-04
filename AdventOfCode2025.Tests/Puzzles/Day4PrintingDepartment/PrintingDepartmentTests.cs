using AdventOfCode2025.Puzzles.Day4PrintingDepartment;

namespace AdventOfCode2025.Tests.Puzzles.Day4PrintingDepartment;

public class PrintingDepartmentTests
{
    [Theory]
    [MemberData(nameof(GetRollsOfPaper))]
    public void GetRollsOfPaperAccessibleByForkLift_PartOne_FindsRollsOfPaperCorrectly(string[] rollsOfPaper)
    {
        // Act
        int rollsAccessibleByForkLift = PrintingDepartment.PartOne.GetRollsOfPaperAccessibleByForkLift(rollsOfPaper);

        // Assert
        Assert.Equal(13, rollsAccessibleByForkLift);
    }


    [Theory]
    [MemberData(nameof(GetRollsOfPaper))]
    public void GetRollsOfPaperAccessibleByForkLift_PartTwo_FindsRollsOfPaperCorrectly(string[] rollsOfPaper)
    {
        // Act
        int rollsAccessibleByForkLift = PrintingDepartment.PartTwo.GetRollsOfPaperAccessibleByForkLift(rollsOfPaper);

        // Assert
        Assert.Equal(43, rollsAccessibleByForkLift);
    }

    public static TheoryData<string[]> GetRollsOfPaper()
    {
        string[] rollsOfPaper = [
            "..@@.@@@@.",
            "@@@.@.@.@@",
            "@@@@@.@.@@",
            "@.@@@@..@.",
            "@@.@@@@.@@",
            ".@@@@@@@.@",
            ".@.@.@.@@@",
            "@.@@@.@@@@",
            ".@@@@@@@@.",
            "@.@.@@@.@."
        ];

        TheoryData<string[]> data = new TheoryData<string[]>();
        data.Add(rollsOfPaper);

        return data;
    }
}
