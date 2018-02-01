using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Radioactive_Mutant_Vampire_Bunies
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();
            var rows = input[0];
            var columns = input[1];

            int playerRow = -1;
            int playerCol = -1;

            List<char[]> matrix = new List<char[]>();
            for (int i = 0; i < rows; i++)
            {
                String line = Console.ReadLine();
                int playerColumn = line.IndexOf('P');
                if (playerColumn != -1)
                {
                    playerCol = playerColumn;
                    playerRow = i;
                }

                matrix.Add(line.ToCharArray());                
            }

            char[] cmds = Console.ReadLine().ToCharArray();

            bool hasWon = false;
            bool hasDied = false;

            for (int i = 0; i < cmds.Length; i++)
            {
                char cmd = cmds[i];

                switch (cmd) {
                    case 'U':
                        if (playerRow == 0)
                        {
                            hasWon = true;
                            matrix[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow - 1][playerCol] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow - 1][playerCol] = 'P';
                                matrix[playerRow][playerCol] = '.';
                            }
                            playerRow--;
                        }
                        break;
                    case 'D':
                        if (playerRow == rows - 1)
                        {
                            hasWon = true;
                            matrix[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow + 1][playerCol] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow + 1][playerCol] = 'P';
                                matrix[playerRow][playerCol] = '.';
                            }
                            playerRow++;
                        }
                        break;
                    case 'L':
                        if (playerCol == 0)
                        {
                            hasWon = true;
                            matrix[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow][playerCol - 1] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow][playerCol - 1] = 'P';
                                matrix[playerRow][playerCol] = '.';
                            }
                            playerCol--;
                        }
                        break;
                    case 'R':
                        if (playerCol == columns - 1)
                        {
                            hasWon = true;
                            matrix[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow][playerCol + 1] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow][playerCol] = 'P';
                                matrix[playerRow][playerCol] = '.';
                            }
                            playerCol++;
                        }
                        break;
                    default:
                        break;
                }
                List<char[]> tempMatrix = new List<char[]>();

                for (int r = 0; r < rows; r++)
                {
                    tempMatrix.Add(new char[columns]);
                    for (int c = 0; c < columns; c++)
                    {
                        tempMatrix[r][c] = matrix[r][c];
                    }
                }

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        if (matrix[r][c] == 'B')
                        {
                            if (r > 0)
                            {
                                if (matrix[r - 1][c] == 'P')
                                {
                                    hasDied = true;
                                }
                                tempMatrix[r - 1][c] = 'B';
                            }
                            if (r < rows - 1)
                            {
                                if (matrix[r + 1][c] == 'P')
                                {
                                    hasDied = true;
                                }
                                tempMatrix[r + 1][c] = 'B';
                            }
                            if (c > 0)
                            {
                                if (matrix[r][c - 1] == 'P')
                                {
                                    hasDied = true;
                                }
                                tempMatrix[r][c - 1] = 'B';
                            }
                            if (c < columns - 1)
                            {
                                if (matrix[r][c + 1] == 'P')
                                {
                                    hasDied = true;
                                }
                                tempMatrix[r][c + 1] = 'B';
                            }
                        }
                    }
                }
                matrix = tempMatrix;
                if (hasWon)
                {
                    hasDied = false;
                    break;
                }
                if (hasDied)
                {
                    break;
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }


            if (hasWon)
            {
                Console.WriteLine("won: " + playerRow + " " + playerCol);
            }
            else
            {
                Console.WriteLine("dead: " + playerRow + " " + playerCol);
            }
        }
    }
}
