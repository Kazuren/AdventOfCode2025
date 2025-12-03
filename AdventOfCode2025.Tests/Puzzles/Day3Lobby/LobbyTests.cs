using AdventOfCode2025.Puzzles.Day3Lobby;

namespace AdventOfCode2025.Tests.Puzzles.Day3Lobby;

public class LobbyTests
{
    [Theory]
    [InlineData("987654321111111", 98)]
    [InlineData("811111111111119", 89)]
    [InlineData("234234234234278", 78)]
    [InlineData("818181911112111", 92)]
    [InlineData("111111111111112", 12)]
    [InlineData("123456789", 89)]
    [InlineData("191", 91)]
    [InlineData("1928", 98)]
    [InlineData("2411323321122342222312224225222113222113323212322221243612222112223322233231224121422335412222222422", 65)]
    [InlineData("4374393634627266376474276644376666365551634337854472353256224441642396253632315522324245257365668356", 99)]
    [InlineData("3711244732222243223142444247164323521231352152322321223441434923323243328332831842433322323717328123", 98)]
    [InlineData("2222122235222122252212223222222121232322222221222223222222222122211222122221222252222221222213223232", 55)]
    [InlineData("8879295676472661376616867284483222277533464815636138425232993434286212329432338327371364266252457516", 99)]
    public void FindMaxJoltageInBatteryBank_PartOne_FindsMaxJoltageCorrectly(string batteryBank, int expectedJoltage)
    {
        // Act
        int joltage = Lobby.PartOne.FindMaxJoltageOfBatteryBank(batteryBank);

        // Assert
        Assert.Equal(expectedJoltage, joltage);
    }

    [Theory]
    [InlineData("987654321111111", 987654321111)]
    [InlineData("811111111111119", 811111111119)]
    [InlineData("234234234234278", 434234234278)]
    [InlineData("818181911112111", 888911112111)]
    [InlineData("111111111111119", 111111111119)]
    [InlineData("111111111111999", 111111111999)]
    [InlineData("999111111111999", 999111111999)]
    [InlineData("999111511111999", 999511111999)]
    [InlineData("123456789123456", 456789123456)]
    [InlineData("987654321987654", 987654987654)]
    [InlineData("191919191919191", 999191919191)]
    [InlineData("123123123123123", 323123123123)]
    [InlineData("432143214321432", 443214321432)]
    [InlineData("432193214321432", 493214321432)]
    [InlineData("932143214321432", 943214321432)]
    [InlineData("2411323321122342222312224225222113222113323212322221243612222112223322233231224121422335412222222422", 654222222422)]
    [InlineData("2221622224222152224426222251222222222122222234222242222122221242223322224212241222221122222242421221", 665444444422)]
    public void FindMaxJoltageInBatteryBank_PartTwo_FindsMaxJoltageCorrectly(string batteryBank, long expectedJoltage)
    {
        // Act
        long joltage = Lobby.PartTwo.FindMaxJoltageOfBatteryBank(batteryBank);

        // Assert
        Assert.Equal(expectedJoltage, joltage);
    }

    [Fact]
    public void Run_PartTwo_FindsMaxJoltageCorrectly()
    {
        // Act
        string[] banks = [
            "987654321111111",
            "811111111111119",
            "234234234234278",
            "818181911112111",
            "111111111111119",
            "111111111111999",
            "999111111111999",
            "999111511111999",
            "123456789123456",
            "987654321987654",
            "191919191919191",
            "123123123123123",
            "432143214321432",
            "432193214321432",
            "932143214321432",
        ];

        // Assert
        Assert.Equal(987654321111
            + 811111111119
            + 434234234278
            + 888911112111
            + 111111111119
            + 111111111999
            + 999111111999
            + 999511111999
            + 456789123456
            + 987654987654
            + 999191919191
            + 323123123123
            + 443214321432
            + 493214321432
            + 943214321432,
            banks.Sum(b => Lobby.PartTwo.FindMaxJoltageOfBatteryBank(b)));
    }
}

