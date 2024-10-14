using ChallengeLogic;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Advent of Code 2023");
            Console.WriteLine("1. Day 1");
            Console.WriteLine("2. Day 2");
            Console.WriteLine("3. Day 3");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                try
                {
                    switch (choice)
                    {
                        case 1:
                            RunDay1();
                            break;
                        case 2:
                            RunDay2();
                            break;
                        case 3:
                            RunDay3();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Invalid choice! Press any key to try again...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.ReadKey();
                }
            }
        }
    }

    static void RunDay1()
    {
        Console.Clear();
        Console.WriteLine("Running Day 1...");
        string[] inputLines = File.ReadAllLines("input.txt");
        var day1 = new Day1();
        int totalCalibrationValue = day1.Part1(inputLines);
        Console.WriteLine("Part 1 Sum of Calibration Values: " + totalCalibrationValue);
        Console.WriteLine("Part 2 Calibration Product: " + day1.Part2(inputLines, totalCalibrationValue));
        Console.ReadKey();
    }

    static void RunDay2()
    {
        Console.Clear();
        Console.WriteLine("Running Day 2...");
        string[] inputLines = File.ReadAllLines("input2.txt");
        var day2 = new Day2();
        Console.WriteLine("Part 1 Total Scoops: " + day2.Part1(inputLines));
        Console.WriteLine("Part 2 Max Scoops: " + day2.Part2(inputLines));
        Console.ReadKey();
    }

    static void RunDay3()
    {
        Console.Clear();
        Console.WriteLine("Running Day 3...");
        string[] inputLines = File.ReadAllLines("input3.txt"); // Make sure this file name is correct
        var day3 = new Day3();
        char[,] grid = day3.ParseGrid(inputLines);
        (int sum, int missingParts) = day3.Part1(grid);
        Console.WriteLine("Part 1 Sum of Part Numbers: " + sum);
        Console.WriteLine("Part 1 Missing Parts: " + missingParts);
        Console.ReadKey();
    }
}