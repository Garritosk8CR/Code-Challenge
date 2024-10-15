using System;
using System.Text.RegularExpressions;

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
        string[] digitWords = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        public int Part2(string[] inputLines)
        {
            return inputLines.Sum(line =>
            {
                string firstMatch = FindFirstMatch(line);
                string lastMatch = FindLastMatch(line);

                if (firstMatch == null || lastMatch == null)
                {
                    Console.WriteLine($"Skipping line: {line}");
                    return 0; // Skip lines where no valid digits are found
                }

                int firstDigit = char.IsDigit(firstMatch[0]) ? int.Parse(firstMatch) : ConvertWordToDigit(firstMatch);
                int lastDigit = char.IsDigit(lastMatch[0]) ? int.Parse(lastMatch) : ConvertWordToDigit(lastMatch);

                Console.WriteLine($"Line: {line}");
                Console.WriteLine($"First Match: {firstMatch}, First Digit: {firstDigit}");
                Console.WriteLine($"Last Match: {lastMatch}, Last Digit: {lastDigit}");
                Console.WriteLine($"Calibration Value: {int.Parse($"{firstDigit}{lastDigit}")}");

                return int.Parse($"{firstDigit}{lastDigit}");
            });
        }

private string FindFirstMatch(string line)
        {
            int digitIndex = -1;
            int wordIndex = -1;
            string wordMatch = null;

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    if (digitIndex == -1)
                    {
                        digitIndex = i;
                    }
                }
                else
                {
                    foreach (var digit in digitWords)
                    {
                        if (i + digit.Length <= line.Length && line.Substring(i, digit.Length).Equals(digit, StringComparison.OrdinalIgnoreCase))
                        {
                            if (wordIndex == -1 || i < wordIndex)
                            {
                                wordIndex = i;
                                wordMatch = digit;
                            }
                            break;
                        }
                    }
                }
            }

            if (digitIndex != -1 && wordIndex != -1)
            {
                return digitIndex < wordIndex ? line.Substring(digitIndex, 1) : wordMatch;
            }
            else if (digitIndex != -1)
            {
                return line.Substring(digitIndex, 1);
            }
            else if (wordIndex != -1)
            {
                return wordMatch;
            }

            return null;
        }

        private string FindLastMatch(string line)
        {
            int digitIndex = -1;
            int wordIndex = -1;
            string wordMatch = null;

            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    if (digitIndex == -1)
                    {
                        digitIndex = i;
                    }
                }
                else
                {
                    foreach (var digit in digitWords.OrderByDescending(d => d.Length))
                    {
                        if (i - digit.Length + 1 >= 0 && line.Substring(i - digit.Length + 1, digit.Length).Equals(digit, StringComparison.OrdinalIgnoreCase))
                        {
                            if (wordIndex == -1 || i > wordIndex)
                            {
                                wordIndex = i;
                                wordMatch = digit;
                            }
                            break;
                        }
                    }
                }
            }

            if (digitIndex != -1 && wordIndex != -1)
            {
                return digitIndex > wordIndex ? line.Substring(digitIndex, 1) : wordMatch;
            }
            else if (digitIndex != -1)
            {
                return line.Substring(digitIndex, 1);
            }
            else if (wordIndex != -1)
            {
                return wordMatch;
            }

            return null;
        }

        private int ConvertWordToDigit(string word)
        {
            if (word == null) throw new ArgumentException("Word cannot be null");

            switch (word.ToLower())
            {
                case "one":
                    return 1;
                case "two":
                    return 2;
                case "three":
                    return 3;
                case "four":
                    return 4;
                case "five":
                    return 5;
                case "six":
                    return 6;
                case "seven":
                    return 7;
                case "eight":
                    return 8;
                case "nine":
                    return 9;
                default:
                    throw new ArgumentException("Invalid word for digit conversion");
            }
        }
    }
}