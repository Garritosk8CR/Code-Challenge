using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeLogic
{
    public class Day3
    {
        public Day3()
        {
        }

        public (int sum, int missingParts) Part1(char[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            int sum = 0;
            int missingParts = 0;

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

                        if (IsAdjacentToSymbol(grid, i, j) || IsAdjacentToSymbol(grid, i, k - 1))
                        {
                            sum += number;
                        }
                        else
                        {
                            missingParts++;
                        }

                        j = k - 1; // Skip the rest of the digits in the current number
                    }
                }
            }
            return (sum, missingParts);
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
                    if (grid[newRow, newCol] == '*' || grid[newRow, newCol] == '#' || grid[newRow, newCol] == '+' || grid[newRow, newCol] == '$')
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
            int cols = inputLines[0].Length;
            char[,] grid = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j < inputLines[i].Length)
                    {
                        grid[i, j] = inputLines[i][j];
                    }
                }
            }
            return grid;
        }
    }
}
