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

        public int Part1(string[] inputLines)
        {
            var redCubes = new List<int>();
            var greenCubes = new List<int>();
            var blueCubes = new List<int>();

            foreach (var line in inputLines)
            {
                var parts = line.Split(' ');
                int cubes = int.Parse(parts[1]);
                if (parts[0] == "red")
                {
                    redCubes.Add(cubes);
                }
                else if (parts[0] == "green")
                {
                    greenCubes.Add(cubes);
                }
                else if (parts[0] == "blue")
                {
                    blueCubes.Add(cubes);
                }
            }

            return redCubes.OrderBy(x => x).Take(3).Aggregate((a, b) => a * b) *
                   greenCubes.OrderBy(x => x).Take(3).Aggregate((a, b) => a * b) *
                   blueCubes.OrderBy(x => x).Take(3).Aggregate((a, b) => a * b);
        }

        public int Part2(string[] inputLines)
        {
            var redCubes = new List<int>();
            var greenCubes = new List<int>();
            var blueCubes = new List<int>();

            foreach (var line in inputLines)
            {
                var parts = line.Split(' ');
                int cubes = int.Parse(parts[1]);
                if (parts[0] == "red")
                {
                    redCubes.Add(cubes);
                }
                else if (parts[0] == "green")
                {
                    greenCubes.Add(cubes);
                }
                else if (parts[0] == "blue")
                {
                    blueCubes.Add(cubes);
                }
            }

            return redCubes.OrderBy(x => x).Take(3).Sum() *
                   greenCubes.OrderBy(x => x).Take(3).Sum() *
                   blueCubes.OrderBy(x => x).Take(3).Sum();
        }
    }
}
