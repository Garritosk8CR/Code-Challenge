using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeLogic
{
    public class Day2
    {
        public Day2()
        {
        }

        public int Part1Final(string lines)
        {
            var runninTotal = 0;
            const int maxRed = 12;
            const int maxGreen = 13;
            const int maxBlue = 14;

            foreach (var line in lines.Split('\n'))
            {
                var gameInfo = line.Split(":");
                var gameId = int.Parse(gameInfo[0].Split(' ')[1]);
                var rounds = gameInfo[1].Split(';', StringSplitOptions.TrimEntries);
                bool isGameValid = true;

                foreach (var round in rounds)
                {
                    var colorInfos = round.Split(',', StringSplitOptions.TrimEntries);
                    foreach(var color in colorInfos)
                    {
                        var colorInfo = color.Split(' ');
                        var colorCount = int.Parse(colorInfo[0]);
                        var colorName = colorInfo[1];

                        switch (colorName)
                        {
                            case "red":
                                if (colorCount > maxRed)
                                {
                                    isGameValid = false;                        
                                }
                                break;
                            case "green":
                                if (colorCount > maxGreen)
                                {
                                    isGameValid = false;
                                }
                                break;
                            case "blue":
                                if (colorCount > maxBlue)
                                {
                                    isGameValid = false;
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    if(!isGameValid)
                    {
                        break;
                    }
                }

                if (isGameValid)
                {
                    runninTotal += gameId;
                }
            }
            return runninTotal;
        }


        public int Part2Final(string lines)
        {
            var runninTotal = 0;
            

            foreach (var line in lines.Split('\n'))
            {
                var gameInfo = line.Split(":");
                var gameId = int.Parse(gameInfo[0].Split(' ')[1]);
                var rounds = gameInfo[1].Split(';', StringSplitOptions.TrimEntries);
                var maxRed = 0;
                var maxGreen = 0;
                var maxBlue = 0;

                foreach (var round in rounds)
                {
                    var colorInfos = round.Split(',', StringSplitOptions.TrimEntries);
                    foreach (var color in colorInfos)
                    {
                        var colorInfo = color.Split(' ');
                        var colorCount = int.Parse(colorInfo[0]);
                        var colorName = colorInfo[1];

                        switch (colorName)
                        {
                            case "red":
                                maxRed = Math.Max(colorCount, maxRed);
                                break;
                            case "green":
                               maxGreen = Math.Max(colorCount, maxGreen);
                                break;
                            case "blue":
                                maxBlue = Math.Max(colorCount, maxBlue);
                                break;
                            default:
                                break;
                        }
                    }
                }

                var result = maxRed * maxGreen * maxBlue;
                runninTotal += result;
            }
            return runninTotal;
        }
    }
}
