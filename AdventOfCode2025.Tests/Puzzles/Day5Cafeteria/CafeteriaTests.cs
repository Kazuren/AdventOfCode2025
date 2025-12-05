using AdventOfCode2025.Puzzles.Day5Cafeteria;

namespace AdventOfCode2025.Tests.Puzzles.Day5Cafeteria;

public class CafeteriaTests
{
    [Theory]
    [MemberData(nameof(GetDatabase))]
    public void GetFreshIngredientsFromDatabase_PartOne_ReturnsFreshIngredients(string[] database)
    {
        int freshIngredientsCount = Cafeteria.PartOne.GetFreshIngredientsFromDatabase(database);

        Assert.Equal(3, freshIngredientsCount);
    }

    [Theory]
    [MemberData(nameof(GetDatabasePartTwo))]
    public void GetFreshIngredientsFromDatabase_PartTwo_ReturnsFreshIngredients(string[] database, long expected)
    {
        long freshIngredientsCount = Cafeteria.PartTwo.GetFreshIngredientsFromDatabase(database);

        Assert.Equal(expected, freshIngredientsCount);
    }

    public static TheoryData<string[]> GetDatabase()
    {
        string[] database = [
            "3-5",
            "10-14",
            "16-20",
            "12-18",
            "",
            "1",
            "5",
            "8",
            "11",
            "17",
            "32"
        ];

        TheoryData<string[]> data = new TheoryData<string[]>();
        data.Add(database);

        return data;
    }

    public static TheoryData<string[], long> GetDatabasePartTwo()
    {
        string[] database = [
            "2-6",
            "3-4",
            "7-9",
            "16-20"
        ];

        TheoryData<string[], long> data = new TheoryData<string[], long>();
        data.Add(database, 13);


        string[] database2 = [
            "3-5",
            "10-14",
            "16-20",
            "12-18",
            "",
            "1",
            "5",
            "8",
            "11",
            "17",
            "32"
        ];
        data.Add(database2, 14);

        string[] database3 = [
            "1-5",
            "1-8",
            "9-11",
            "11-12",
            "200-299"
       ];
        data.Add(database3, 112);


        string[] database4 = [
            "1-10",
            "2-20",
            "5-15",
            "8-25",
            "9-9"
        ];
        data.Add(database4, 25);

        string[] database5 = [
            "1-3",
            "3-10",
            "10-15",
            "15-20",
            "20-30"
         ];
        data.Add(database5, 30);

        return data;
    }
}
