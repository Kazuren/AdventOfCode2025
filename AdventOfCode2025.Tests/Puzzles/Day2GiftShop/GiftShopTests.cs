
using AdventOfCode2025.Puzzles;
namespace AdventOfCode2025.Tests.Puzzles;

public class GiftShopTests
{
    [Fact]
    public void ParseProductRange_CorrectlyParsesProductRange()
    {
        GiftShop.ProductRange range = GiftShop.ParseProductRange("500-1000");
        Assert.Equal(500, range.Start);
        Assert.Equal(1000, range.End);

        GiftShop.ProductRange range2 = GiftShop.ParseProductRange("500-500");
        Assert.Equal(500, range2.Start);
        Assert.Equal(500, range2.End);

        GiftShop.ProductRange range3 = GiftShop.ParseProductRange("0-0");
        Assert.Equal(0, range3.Start);
        Assert.Equal(0, range3.End);

        GiftShop.ProductRange range4 = GiftShop.ParseProductRange($"{long.MaxValue}-{long.MaxValue}");
        Assert.Equal(long.MaxValue, range4.Start);
        Assert.Equal(long.MaxValue, range4.End);

        Assert.Throws<InvalidOperationException>(() => { GiftShop.ParseProductRange(""); });
        Assert.Throws<InvalidOperationException>(() => { GiftShop.ParseProductRange("0-1-2"); });
        Assert.Throws<InvalidOperationException>(() => { GiftShop.ParseProductRange(null!); });
        Assert.Throws<InvalidOperationException>(() => { GiftShop.ParseProductRange("0-seven"); });
        Assert.Throws<InvalidOperationException>(() => { GiftShop.ParseProductRange("seven-0"); });
    }

    [Fact]
    public void ParseMultipleProductRanges_CorrectlyParsesProductRanges()
    {
        GiftShop.ProductRange[] range = GiftShop.ParseMultipleProductRanges($"500-1000,0-0,1-{long.MaxValue}");

        Assert.Equal(3, range.Length);
        Assert.Equal(500, range[0].Start);
        Assert.Equal(1000, range[0].End);

        Assert.Equal(0, range[1].Start);
        Assert.Equal(0, range[1].End);

        Assert.Equal(1, range[2].Start);
        Assert.Equal(long.MaxValue, range[2].End);

        Assert.Throws<InvalidOperationException>(() => { GiftShop.ParseMultipleProductRanges("0-5,0-seven,1-3"); });
    }

    [Fact]
    public void CountInvalidProductIdsInProductRange_PartOne_CountsCorrectly()
    {
        Assert.Equal([11, 22], GiftShop.PartOne.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 11, End = 22 }));
        Assert.Equal([99], GiftShop.PartOne.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 95, End = 115 }));
        Assert.Equal([1010], GiftShop.PartOne.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 998, End = 1012 }));
        Assert.Equal([1188511885], GiftShop.PartOne.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 1188511880, End = 1188511890 }));
        Assert.Equal([222222], GiftShop.PartOne.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 222220, End = 222224 }));
        Assert.Equal([], GiftShop.PartOne.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 1698522, End = 1698528 }));
        Assert.Equal([446446], GiftShop.PartOne.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 446443, End = 446449 }));
        Assert.Equal([38593859], GiftShop.PartOne.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 38593856, End = 38593862 }));
    }

    [Fact]
    public void CountInvalidProductIdsInProductRanges_PartOne_CountsCorrectly()
    {
        Assert.Equal([11, 22, 99, 1010, 1188511885, 222222, 446446, 38593859],
            GiftShop.PartOne.CountInvalidIdsInProductRanges([
                new GiftShop.ProductRange { Start = 11, End = 22 },
                new GiftShop.ProductRange { Start = 95, End = 115 },
                new GiftShop.ProductRange { Start = 998, End = 1012 },
                new GiftShop.ProductRange { Start = 1188511880, End = 1188511890 },
                new GiftShop.ProductRange { Start = 222220, End = 222224 },
                new GiftShop.ProductRange { Start = 1698522, End = 1698528 },
                new GiftShop.ProductRange { Start = 446443, End = 446449 },
                new GiftShop.ProductRange { Start = 38593856, End = 38593862 },
            ])
        );
    }


    [Fact]
    public void ProductIdIsInvalid_PartTwo_CountsCorrectly()
    {
        Assert.False(GiftShop.PartTwo.ProductIdIsInvalid(12));
        Assert.True(GiftShop.PartTwo.ProductIdIsInvalid(111));
        Assert.True(GiftShop.PartTwo.ProductIdIsInvalid(12341234));
        Assert.True(GiftShop.PartTwo.ProductIdIsInvalid(123123123));
        Assert.True(GiftShop.PartTwo.ProductIdIsInvalid(1212121212));
        Assert.True(GiftShop.PartTwo.ProductIdIsInvalid(1111111));
    }

    [Fact]
    public void CountInvalidProductIdsInProductRange_PartTwo_CountsCorrectly()
    {
        Assert.Equal([11, 22], GiftShop.PartTwo.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 11, End = 22 }));
        Assert.Equal([99, 111], GiftShop.PartTwo.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 95, End = 115 }));
        Assert.Equal([999, 1010], GiftShop.PartTwo.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 998, End = 1012 }));
        Assert.Equal([1188511885], GiftShop.PartTwo.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 1188511880, End = 1188511890 }));
        Assert.Equal([222222], GiftShop.PartTwo.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 222220, End = 222224 }));
        Assert.Equal([], GiftShop.PartTwo.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 1698522, End = 1698528 }));
        Assert.Equal([446446], GiftShop.PartTwo.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 446443, End = 446449 }));
        Assert.Equal([38593859], GiftShop.PartTwo.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 38593856, End = 38593862 }));
        Assert.Equal([565656], GiftShop.PartTwo.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 565653, End = 565659 }));
        Assert.Equal([824824824], GiftShop.PartTwo.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 824824821, End = 824824827 }));
        Assert.Equal([2121212121], GiftShop.PartTwo.CountInvalidIdsInProductRange(new GiftShop.ProductRange { Start = 2121212118, End = 2121212124 }));
    }

    [Fact]
    public void CountInvalidProductIdsInProductRanges_PartTwo_CountsCorrectly()
    {
        Assert.Equal([11, 22, 99, 111, 999, 1010, 1188511885, 222222, 446446, 38593859, 565656, 824824824, 2121212121],
            GiftShop.PartTwo.CountInvalidIdsInProductRanges([
                new GiftShop.ProductRange { Start = 11, End = 22 },
                new GiftShop.ProductRange { Start = 95, End = 115 },
                new GiftShop.ProductRange { Start = 998, End = 1012 },
                new GiftShop.ProductRange { Start = 1188511880, End = 1188511890 },
                new GiftShop.ProductRange { Start = 222220, End = 222224 },
                new GiftShop.ProductRange { Start = 1698522, End = 1698528 },
                new GiftShop.ProductRange { Start = 446443, End = 446449 },
                new GiftShop.ProductRange { Start = 38593856, End = 38593862 },
                new GiftShop.ProductRange { Start = 565653, End = 565659 },
                new GiftShop.ProductRange { Start = 824824821, End = 824824827 },
                new GiftShop.ProductRange { Start = 2121212118, End = 2121212124 },
            ])
        );
    }
}
