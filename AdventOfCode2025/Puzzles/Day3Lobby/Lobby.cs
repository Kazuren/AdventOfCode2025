namespace AdventOfCode2025.Puzzles.Day3Lobby;

public static class Lobby
{
    public static class PartOne
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The total output joltage of all banks from the sum of the maximum output joltage of each bank.</returns>
        public static int Run()
        {
            string[] batteryBanks = File.ReadAllLines("./Puzzles/Day3Lobby/Input.txt");

            return batteryBanks.Sum(bank => FindMaxJoltageOfBatteryBank(bank));
        }

        public static int FindMaxJoltageOfBatteryBank(string bank)
        {
            byte[] joltageRatings = bank.Select(c => (byte)Char.GetNumericValue(c)).ToArray();
            if (!joltageRatings.All(joltage => joltage > 0 && joltage <= 9))
            {
                throw new InvalidOperationException("Invalid battery bank!");
            }

            int p1 = 0;
            int p2 = 1;

            for (int batteryIndex = 0; batteryIndex < joltageRatings.Length; batteryIndex++)
            {
                byte currentJoltageRating = joltageRatings[batteryIndex];
                if (currentJoltageRating > joltageRatings[p1])
                {
                    if (batteryIndex != joltageRatings.Length - 1)
                    {
                        p1 = batteryIndex;
                        p2 = batteryIndex + 1;
                    }
                }

                if (currentJoltageRating > joltageRatings[p2] && p1 != batteryIndex)
                {
                    p2 = batteryIndex;
                }
            }

            return joltageRatings[p1] * 10 + joltageRatings[p2];
        }
    }

    public static class PartTwo
    {
        public static long Run()
        {
            string[] batteryBanks = File.ReadAllLines("./Puzzles/Day3Lobby/Input.txt");
            return batteryBanks.Sum(bank => FindMaxJoltageOfBatteryBank(bank));
        }

        public static long FindMaxJoltageOfBatteryBank(string bank)
        {
            byte[] joltageRatings = bank.Select(c => (byte)Char.GetNumericValue(c)).ToArray();
            if (!joltageRatings.All(joltage => joltage > 0 && joltage <= 9))
            {
                throw new InvalidOperationException("Invalid battery bank!");
            }

            Stack<int> joltageStack = new Stack<int>();
            const int TOTAL_BATTERIES_NEEDED = 12;
            for (int batteryIndex = 0; batteryIndex < joltageRatings.Length; batteryIndex++)
            {
                while (joltageStack.Count > 0 && (joltageStack.Peek() < joltageRatings[batteryIndex]) && (joltageRatings.Length - batteryIndex) > TOTAL_BATTERIES_NEEDED - joltageStack.Count)
                {
                    joltageStack.Pop();
                }
                if (joltageStack.Count < 12)
                {
                    joltageStack.Push(joltageRatings[batteryIndex]);
                }
            }

            long maxJoltage = 0;
            for (int i = 0; i < 12; i++)
            {
                maxJoltage += joltageStack.Pop() * (long)Math.Pow(10, i);
            }
            return maxJoltage;
        }
    }
}
