namespace ChallengeLogic
{
    public class Day1
    {
        public int Part1(string[] inputLines)
        {
            return inputLines.Sum(line =>
            {
                char firstDigit = line.First(char.IsDigit);
                char lastDigit = line.Last(char.IsDigit);
                return int.Parse($"{firstDigit}{lastDigit}");
            });
        }

        public int Part2(string[] inputLines, int totalCalibrationValue)
        {
            int minCalibrationValue = inputLines.Min(line =>
            {
                char firstDigit = line.First(char.IsDigit);
                char lastDigit = line.Last(char.IsDigit);
                return int.Parse($"{firstDigit}{lastDigit}");
            });

            return minCalibrationValue * totalCalibrationValue;
        }

    }
}