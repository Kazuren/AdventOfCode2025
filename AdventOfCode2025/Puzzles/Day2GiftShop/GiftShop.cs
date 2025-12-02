namespace AdventOfCode2025.Puzzles;

public static class GiftShop
{
    public readonly record struct ProductRange
    {
        public required long Start { get; init; }
        public required long End { get; init; }

    }
    public static class PartOne
    {
        /// <summary>
        /// Part 1 <br/>
        /// https://adventofcode.com/2025/day/2 
        /// </summary>
        /// <returns>The sum of all invalid ids</returns>
        public static long Run()
        {
            return CountInvalidIdsInProductRanges(ParseMultipleProductRanges(File.ReadAllText("./Puzzles/Day2GiftShop/Input.txt"))).Sum();
        }

        public static HashSet<long> CountInvalidIdsInProductRange(ProductRange range)
        {
            HashSet<long> invalidIds = new HashSet<long>();
            for (long currentValue = range.Start; currentValue <= range.End; currentValue++)
            {
                if (IsOdd(GetDigitCount(currentValue)))
                {
                    continue;
                }

                string stringValue = currentValue.ToString();
                ReadOnlySpan<char> firstHalf = stringValue.AsSpan(0, stringValue.Length / 2);
                ReadOnlySpan<char> secondHalf = stringValue.AsSpan(stringValue.Length / 2);
                if (firstHalf.SequenceEqual(secondHalf))
                {
                    invalidIds.Add(currentValue);
                }
            }

            return invalidIds;
        }

        public static HashSet<long> CountInvalidIdsInProductRanges(IEnumerable<ProductRange> ranges)
        {
            return ranges.SelectMany(r => CountInvalidIdsInProductRange(r)).ToHashSet<long>();
        }
    }

    public static class PartTwo
    {
        /// <summary>
        /// Part 2 <br/>
        /// https://adventofcode.com/2025/day/2 
        /// </summary>
        /// <returns>The sum of all invalid ids</returns>
        public static long Run()
        {
            return CountInvalidIdsInProductRanges(ParseMultipleProductRanges(File.ReadAllText("./Puzzles/Day2GiftShop/Input.txt"))).Sum();
        }

        public static HashSet<long> CountInvalidIdsInProductRange(ProductRange range)
        {
            HashSet<long> invalidIds = new HashSet<long>();
            for (long currentValue = range.Start; currentValue <= range.End; currentValue++)
            {
                if (ProductIdIsInvalid(currentValue))
                {
                    invalidIds.Add(currentValue);
                }
            }

            return invalidIds;
        }

        public static HashSet<long> CountInvalidIdsInProductRanges(IEnumerable<ProductRange> ranges)
        {
            return ranges.SelectMany(r => CountInvalidIdsInProductRange(r)).ToHashSet<long>();
        }

        public static bool ProductIdIsInvalid(long productId)
        {
            string stringValue = productId.ToString();

            // Divide the string into equal length parts for each factor of string.Length
            // and compare if all the parts are equal.
            // if all parts are equal we have an invalid product id
            for (int divisor = stringValue.Length; divisor > 1; divisor--)
            {
                if (stringValue.Length % divisor != 0)
                {
                    continue;
                }

                int increment = stringValue.Length / divisor;
                int start = 0;
                ReadOnlySpan<char> previousSpan = ReadOnlySpan<char>.Empty;
                while (start < stringValue.Length)
                {
                    ReadOnlySpan<char> currentSpan = stringValue.AsSpan(start, increment);
                    if (previousSpan != ReadOnlySpan<char>.Empty && !currentSpan.SequenceEqual(previousSpan))
                    {
                        break;
                    }
                    previousSpan = currentSpan;
                    start += increment;
                }

                if (start >= stringValue.Length)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public static ProductRange ParseProductRange(string productRangeString)
    {
        if (string.IsNullOrWhiteSpace(productRangeString))
        {
            throw new InvalidOperationException("Product range string was not in the correct format");
        }

        string[] splitRange = productRangeString.Split('-');
        if (splitRange.Length != 2)
        {
            throw new InvalidOperationException("Product range string was not in the correct format");
        }

        string startValue = splitRange[0];
        string endValue = splitRange[1];

        if (!long.TryParse(startValue, out long parsedStartValue))
        {
            throw new InvalidOperationException("Product range string was not in the correct format");
        }

        if (!long.TryParse(endValue, out long parsedEndValue))
        {
            throw new InvalidOperationException("Product range string was not in the correct format");
        }

        return new ProductRange() { Start = parsedStartValue, End = parsedEndValue };
    }

    public static ProductRange[] ParseMultipleProductRanges(string productRangesString)
    {
        string[] productRanges = productRangesString.Split(',');
        return productRanges.Select(ParseProductRange).ToArray();
    }


    private static bool IsOdd(long number)
    {
        return number % 2 != 0;
    }

    private static int GetDigitCount(long number)
    {
        return (int)Math.Floor(Math.Log10(number) + 1);
    }
}

