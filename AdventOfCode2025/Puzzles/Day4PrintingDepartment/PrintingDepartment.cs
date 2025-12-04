namespace AdventOfCode2025.Puzzles.Day4PrintingDepartment;

public static class PrintingDepartment
{

    public static class PartOne
    {
        public static int Run()
        {
            string[] lines = File.ReadAllLines("./Puzzles/Day4PrintingDepartment/Input.txt");

            return GetRollsOfPaperAccessibleByForkLift(lines);
        }

        public static int GetRollsOfPaperAccessibleByForkLift(string[] rollsOfPaper)
        {
            int width = rollsOfPaper[0].Length;
            int height = rollsOfPaper.Length;

            bool[,] rollsOnGrid = new bool[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (rollsOfPaper[y][x] == '@')
                    {
                        rollsOnGrid[y, x] = true;
                    }
                }
            }

            int[,] adjacentRollsOnGrid = new int[width, height];


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!rollsOnGrid[y, x]) { continue; }

                    if (y + 1 < height && x - 1 >= 0 && rollsOnGrid[y + 1, x - 1])
                    {
                        adjacentRollsOnGrid[y, x] += 1;
                        adjacentRollsOnGrid[y + 1, x - 1] += 1;
                    }

                    if (y + 1 < height && rollsOnGrid[y + 1, x])
                    {
                        adjacentRollsOnGrid[y, x] += 1;
                        adjacentRollsOnGrid[y + 1, x] += 1;
                    }

                    if (y + 1 < height && x + 1 < width && rollsOnGrid[y + 1, x + 1])
                    {
                        adjacentRollsOnGrid[y, x] += 1;
                        adjacentRollsOnGrid[y + 1, x + 1] += 1;
                    }

                    if (x + 1 < width && rollsOnGrid[y, x + 1])
                    {
                        adjacentRollsOnGrid[y, x] += 1;
                        adjacentRollsOnGrid[y, x + 1] += 1;
                    }
                }
            }


            int rollsAccessibleByForkLift = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (rollsOnGrid[y, x] && adjacentRollsOnGrid[y, x] < 4)
                    {
                        rollsAccessibleByForkLift += 1;
                    }
                }
            }

            return rollsAccessibleByForkLift;
        }
    }

    public static class PartTwo
    {
        public static int Run()
        {
            string[] lines = File.ReadAllLines("./Puzzles/Day4PrintingDepartment/Input.txt");

            return GetRollsOfPaperAccessibleByForkLift(lines);
        }

        public static int GetRollsOfPaperAccessibleByForkLift(string[] rollsOfPaper)
        {
            int width = rollsOfPaper[0].Length;
            int height = rollsOfPaper.Length;

            bool[,] rollsOnGrid = new bool[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (rollsOfPaper[y][x] == '@')
                    {
                        rollsOnGrid[y, x] = true;
                    }
                }
            }

            int totalRowsAccessibleByForkLift = 0;
            int rollsAccessibleByForkLift;
            do
            {
                rollsAccessibleByForkLift = 0;
                int[,] adjacentRollsOnGrid = new int[width, height];

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (!rollsOnGrid[y, x]) { continue; }

                        if (y + 1 < height && x - 1 >= 0 && rollsOnGrid[y + 1, x - 1])
                        {
                            adjacentRollsOnGrid[y, x] += 1;
                            adjacentRollsOnGrid[y + 1, x - 1] += 1;
                        }

                        if (y + 1 < height && rollsOnGrid[y + 1, x])
                        {
                            adjacentRollsOnGrid[y, x] += 1;
                            adjacentRollsOnGrid[y + 1, x] += 1;
                        }

                        if (y + 1 < height && x + 1 < width && rollsOnGrid[y + 1, x + 1])
                        {
                            adjacentRollsOnGrid[y, x] += 1;
                            adjacentRollsOnGrid[y + 1, x + 1] += 1;
                        }

                        if (x + 1 < width && rollsOnGrid[y, x + 1])
                        {
                            adjacentRollsOnGrid[y, x] += 1;
                            adjacentRollsOnGrid[y, x + 1] += 1;
                        }
                    }
                }


                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (rollsOnGrid[y, x] && adjacentRollsOnGrid[y, x] < 4)
                        {
                            rollsAccessibleByForkLift += 1;
                            rollsOnGrid[y, x] = false;
                        }
                    }
                }
                totalRowsAccessibleByForkLift += rollsAccessibleByForkLift;
            } while (rollsAccessibleByForkLift > 0);
            return totalRowsAccessibleByForkLift;
        }
    }
}
