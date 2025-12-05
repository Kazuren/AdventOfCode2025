namespace AdventOfCode2025.Puzzles.Day5Cafeteria;

public static class Cafeteria
{
    public static class PartOne
    {
        public static int Run()
        {
            string[] database = File.ReadAllLines("./Puzzles/Day5Cafeteria/Input.txt");
            return GetFreshIngredientsFromDatabase(database);
        }

        public static int GetFreshIngredientsFromDatabase(string[] database)
        {
            int ingredientIdStartIndex = database.ToList().FindIndex(0, line => string.IsNullOrWhiteSpace(line));

            IEnumerable<IngredientIdRange> ingredientRanges = ParseIngredientIdRanges(database[0..ingredientIdStartIndex]);
            IEnumerable<long> ingredientIds = ParseIngredientIds(database[(ingredientIdStartIndex + 1)..]);


            List<IngredientIdRange> sortedIngredientRanges = ingredientRanges.OrderBy(r => r.Start).ThenBy(r => r.End - r.Start).ToList();
            List<long> sortedIngredientIds = ingredientIds.OrderBy(x => x).ToList();

            int freshIngredients = 0;

            int rangeIndex = 0;
            int ingredientIndex = 0;
            while (ingredientIndex < sortedIngredientIds.Count && rangeIndex < sortedIngredientRanges.Count)
            {
                IngredientIdRange range = sortedIngredientRanges[rangeIndex];
                long currentIngredientId = sortedIngredientIds[ingredientIndex];
                while (currentIngredientId < range.Start)
                {
                    ingredientIndex++;
                    currentIngredientId = sortedIngredientIds[ingredientIndex];
                }

                while (currentIngredientId <= range.End)
                {
                    freshIngredients++;
                    ingredientIndex++;
                    currentIngredientId = sortedIngredientIds[ingredientIndex];
                }

                rangeIndex++;
            }

            return freshIngredients;
        }
    }

    public static class PartTwo
    {
        public static long Run()
        {
            string[] database = File.ReadAllLines("./Puzzles/Day5Cafeteria/Input.txt");
            return GetFreshIngredientsFromDatabase(database); ;
        }

        public static long GetFreshIngredientsFromDatabase(string[] database)
        {
            int endOfIngredientIdRangesIndex = database.ToList().FindIndex(0, line => string.IsNullOrWhiteSpace(line));
            if (endOfIngredientIdRangesIndex == -1)
            {
                endOfIngredientIdRangesIndex = database.Length;
            }

            IEnumerable<IngredientIdRange> ingredientRanges = ParseIngredientIdRanges(database[0..endOfIngredientIdRangesIndex]);

            List<IngredientIdRange> sortedIngredientRanges = ingredientRanges.OrderBy(r => r.Start).ThenBy(r => r.End - r.Start).ToList();

            int rangeIndex = 0;
            long freshIngredients = 0;
            while (rangeIndex < sortedIngredientRanges.Count)
            {
                IngredientIdRange currentRange = sortedIngredientRanges[rangeIndex];

                if (rangeIndex + 1 == sortedIngredientRanges.Count)
                {
                    freshIngredients += (currentRange.End - currentRange.Start) + 1;
                    break;
                }

                IngredientIdRange nextRange = sortedIngredientRanges[rangeIndex + 1];

                while (currentRange.End >= nextRange.End)
                {
                    rangeIndex++;

                    if (rangeIndex + 1 == sortedIngredientRanges.Count)
                    {
                        break;
                    }

                    nextRange = sortedIngredientRanges[rangeIndex + 1];
                }

                if (rangeIndex + 1 == sortedIngredientRanges.Count)
                {
                    freshIngredients += (currentRange.End - currentRange.Start) + 1;
                    break;
                }


                if (currentRange.End >= nextRange.Start)
                {
                    freshIngredients -= currentRange.End - (nextRange.Start - 1);
                    freshIngredients += (currentRange.End - currentRange.Start) + 1;
                }
                else
                {
                    freshIngredients += (currentRange.End - currentRange.Start) + 1;
                }

                rangeIndex++;
            }

            return freshIngredients;
        }
    }

    public static IEnumerable<IngredientIdRange> ParseIngredientIdRanges(string[] stringRanges)
    {
        foreach (string range in stringRanges)
        {
            string[] splitRange = range.Split('-');
            yield return new IngredientIdRange()
            {
                Start = long.Parse(splitRange[0]),
                End = long.Parse(splitRange[1])
            };
        }
    }

    public static IEnumerable<long> ParseIngredientIds(string[] ingredientIds)
    {
        foreach (string ingredientId in ingredientIds)
        {
            yield return long.Parse(ingredientId);
        }
    }

    public readonly record struct IngredientIdRange
    {
        public long Start { get; init; }
        public long End { get; init; }
    }
}
