using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeLogic
{
    public class Day3
    {
        public int Part1(char[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (char.IsDigit(grid[i, j]))
                    {
                        int number = 0;
                        int k = j;
                        while (k < cols && char.IsDigit(grid[i, k]))
                        {
                            number = number * 10 + (int)char.GetNumericValue(grid[i, k]);
                            k++;
                        }

                        bool isAdjacent = IsAdjacentToSymbol(grid, i, j) || IsAdjacentToSymbol(grid, i, k - 1);

                        Console.WriteLine($"Found number {number} at ({i}, {j}) - Adjacent to symbol: {isAdjacent}");
                        if (isAdjacent)
                        {
                            sum += number;
                            Console.WriteLine($"Adding {number} to sum. New sum: {sum}");
                        }
                        else
                        {
                            
                        }

                        j = k - 1; // Skip the rest of the digits in the current number
                    }
                }
            }
            return sum;
        }
        private bool IsAdjacentToSymbol(char[,] grid, int row, int col)
        {
            int[] dRow = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dCol = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int k = 0; k < 8; k++)
            {
                int newRow = row + dRow[k];
                int newCol = col + dCol[k];
                if (newRow >= 0 && newRow < grid.GetLength(0) && newCol >= 0 && newCol < grid.GetLength(1))
                {
                    char adjacentChar = grid[newRow, newCol];
                    if (!char.IsDigit(adjacentChar) && adjacentChar != '.')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public char[,] ParseGrid(string[] inputLines)
        {
            int rows = inputLines.Length;
            int maxCols = inputLines.Max(line => line.Length);
            char[,] grid = new char[rows, maxCols];

            for (int i = 0; i < rows; i++)
            {
                string line = inputLines[i];
                for (int j = 0; j < maxCols; j++)
                {
                    if (j < line.Length)
                    {
                        grid[i, j] = line[j];
                    }
                    else
                    {
                        grid[i, j] = ' '; // pad with space if line is shorter
                    }
                }
            }
            return grid;
        }

        public int Part2(string[] input)
        {
            var width = input[0].Length;
            var height = input.Length;
            var map = new char[width, height];

            for (int x = 0; x < width; x++) 
            { 
                for (int y = 0; y < height; y++)
                {
                    map[x, y] = input[x][y];
                }    
            }

            var runningtotal = 0;
            var currentNumber = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var character = map[x, y];
                    if (char.IsDigit(character))
                    {
                        var value = character - '0';
                        currentNumber = currentNumber * 10 + value;
                        foreach(var direction in Directions.WithDiagonals)
                        {
                            var neighborX = x + direction.X;
                            var neighborY = y + direction.Y;
                            if (neighborX < 0 || neighborY >= width || neighborY < 0 || neighborY >= height)
                            {
                                continue;
                            }
                            var neighborCharacter = map[neighborX, neighborY];
                        }
                    }
                }

            }

            return runningtotal;
        }
    }
}
