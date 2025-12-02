namespace AdventOfCode2025.Puzzles;

public static class SecretEntrance
{
    private const int MAX_VALUE = 99;
    private const int MIN_VALUE = 0;
    private const int VALUE_RANGE = (MAX_VALUE + 1 - MIN_VALUE);

    public static class PartOne
    {
        /// <summary>
        /// Part 1 <br/>
        /// https://adventofcode.com/2025/day/1 
        /// </summary>
        /// <returns>The number of times the dial is left pointing at 0 after any rotation in the sequence.</returns>
        public static int Run()
        {
            string[] lines = File.ReadAllLines("./Puzzles/Day1SecretEntrance/Input.txt");

            IEnumerable<DialRotation> rotations = lines.Select(ParseRotationString);

            int value = 50;
            int amountOfTimesLeftPointingAtZero = 0;
            foreach (DialRotation rotation in rotations)
            {
                int rotatedValue = value + rotation.Amount * (int)rotation.Direction;

                if (rotatedValue > MAX_VALUE)
                {
                    value = rotatedValue % VALUE_RANGE;
                }
                else if (rotatedValue < MIN_VALUE)
                {
                    value = rotatedValue + VALUE_RANGE * ((Math.Abs(rotatedValue) / (VALUE_RANGE + 1)) + 1);
                }
                else
                {
                    value = rotatedValue;
                }

                if (value == 0)
                {
                    amountOfTimesLeftPointingAtZero++;
                }
            }

            return amountOfTimesLeftPointingAtZero;
        }


    }
    public static class PartTwo
    {
        /// <summary>
        /// Part 2 <br/>
        /// https://adventofcode.com/2025/day/1 
        /// </summary>
        /// <returns>The number of times any click causes the dial to point at 0. Regardless if it happens during a rotation or at the end of one.</returns>
        public static int Run()
        {
            string[] lines = File.ReadAllLines("./Puzzles/Day1SecretEntrance/Input.txt");

            IEnumerable<DialRotation> rotations = lines.Select(ParseRotationString);

            int amountOfTimesTurnedToZero = 0;
            Dial dial = new Dial();
            foreach (DialRotation rotation in rotations)
            {
                amountOfTimesTurnedToZero += dial.Rotate(rotation);
            }
            return amountOfTimesTurnedToZero;
        }


        public class Dial()
        {
            public int Value { get; private set; } = 50;

            public int Rotate(DialRotation rotation)
            {
                if (rotation.Direction == DialRotation.DirectionEnum.Left)
                {
                    return RotateLeft(rotation.Amount);
                }
                else
                {
                    return RotateRight(rotation.Amount);
                }
            }

            public int RotateLeft(int amount)
            {
                int fullRotations = Math.Abs(amount) / VALUE_RANGE;

                int previousValue = Value;
                Value = Value - (amount % VALUE_RANGE);
                if (Value < MIN_VALUE)
                {
                    Value += VALUE_RANGE;
                    return fullRotations + (previousValue == 0 ? 0 : 1);
                }
                else if (Value == 0)
                {
                    return fullRotations + (previousValue == 0 ? 0 : 1);
                }
                else
                {
                    return fullRotations;
                }
            }

            public int RotateRight(int amount)
            {
                int fullRotations = Math.Abs(amount) / VALUE_RANGE;

                int previousValue = Value;
                Value = Value + (amount % VALUE_RANGE);
                if (Value > MAX_VALUE)
                {
                    Value -= VALUE_RANGE;
                    return fullRotations + (previousValue == 0 ? 0 : 1);
                }
                else if (Value == 0)
                {
                    return fullRotations + (previousValue == 0 ? 0 : 1);
                }
                else
                {
                    return fullRotations;
                }
            }

            public override string ToString()
            {
                return $"Dial({Value})";
            }
        }

    }
    public struct DialRotation
    {
        public enum DirectionEnum { Left = -1, Right = 1 }

        public DirectionEnum Direction { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{(Direction == DirectionEnum.Left ? 'L' : 'R')}{Amount}";
        }
    }

    public static DialRotation ParseRotationString(string rotation)
    {
        DialRotation.DirectionEnum direction;
        if (rotation[0] == 'L')
        {
            direction = DialRotation.DirectionEnum.Left;
        }
        else
        {
            direction = DialRotation.DirectionEnum.Right;
        }

        int amount = int.Parse(new string([.. rotation.Skip(1)]));

        return new DialRotation { Direction = direction, Amount = amount };
    }
}

