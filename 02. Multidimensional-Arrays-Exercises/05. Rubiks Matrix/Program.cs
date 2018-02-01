using System;
using System.Linq;
using System.Text;

namespace _05._Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = tokens[0];
            var columns = tokens[1];
            var dimension = int.Parse(Console.ReadLine());
                        
            var jagged = CreateJaggedMatrix(rows,columns);
            var directionMatrix = ManipulationRubick(dimension, jagged,rows,columns);
            var booferMatrix = CreateJaggedMatrix(rows, columns);

            

            for (int row = 0; row < directionMatrix.Length; row++)
            {
                for (int col = 0; col < directionMatrix[row].Length; col++)
                {
                  // for (int i = 0; i < rows; i++)
                  // {
                  //     for (int k = 0; k < columns; k++)
                  //     {
                  //         Console.Write(directionMatrix[i][k] + " ");
                  //     }
                  //     Console.WriteLine();
                  // }
                  
                    if (directionMatrix[row][col] == booferMatrix[row][col])
                    {
                        Console.WriteLine("No swap required");
                        continue;
                    }
                    else
                    {
                        for (int rowB = 0; rowB < directionMatrix.Length; rowB++)
                        {
                            bool isMatch = false;
                            for (int colB = 0; colB < directionMatrix[row].Length; colB++)
                            {
                                
                                if (directionMatrix[rowB][colB] == booferMatrix[row][col])
                                {                                    
                                    directionMatrix[rowB][colB] = directionMatrix[row][col];
                                    directionMatrix[row][col] = booferMatrix[row][col];

                                    Console.WriteLine("Swap ({0}, {1}) with ({2}, {3})",row,col,rowB,colB);
                                    isMatch = true;
                                    break;
                                }
                                if (isMatch)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }                
            }
        }
        private static int[][] ManipulationRubick(int dimension, int[][] jagged, int rows, int columns)
        {
            for (int i = 0; i < dimension; i++)
            {
                var boofer = 0;

                var commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var rowCol = int.Parse(commands[0]);
                var direction = commands[1];
                var moves = int.Parse(commands[2]);

                if (direction == "left")
                {
                    for (int k = 0; k < moves; k++)
                    {
                        var count = jagged[rowCol].Length - 1;
                        for (int col = 0; col < count; col++)
                        {
                            if (col == 0)
                            {
                                boofer = jagged[rowCol][0];
                            }
                            jagged[rowCol][col] = jagged[rowCol][col + 1];
                            if (col == columns - 2)
                            {
                                jagged[rowCol][col + 1] = boofer;
                            }
                        }
                    }                     
                }
                else if (direction == "right")
                {
                    for (int k = 0; k < moves; k++)
                    {
                        var count = jagged[rowCol].Length - 1;
                        boofer = jagged[rowCol][count];
                        for (int col = 0; col < count; col++)
                        {
                            jagged[rowCol][count - col] = jagged[rowCol][count - col - 1];
                            if (col == count - 1)
                            {
                                jagged[rowCol][col - 2] = boofer;
                            }
                        }
                    }
                }
                else if (direction == "down")
                {
                    for (int k = 0; k < moves; k++)
                    {
                        var count = rows - 1;
                        boofer = jagged[count][rowCol];
                        for (int row = 0; row < count; row++)
                        {
                            jagged[count - row][rowCol] = jagged[count - row - 1][rowCol];
                            if (row == count - 1)
                            {
                                jagged[row - 1][rowCol] = boofer;
                            }
                        }
                    }
                }
                else if (direction == "up")
                {
                    for (int k = 0; k < moves; k++)
                    {
                        var count = rows - 1;
                        boofer = jagged[0][rowCol];
                        for (int col = 0; col < count; col++)
                        {
                            jagged[col][rowCol] = jagged[col + 1][rowCol];
                            if (col == count - 1)
                            {
                                jagged[col + 1][rowCol] = boofer;
                            }
                        }
                    }
                }                
            }
            return jagged;
        }

        private static int[][] CreateJaggedMatrix(int rows,int columns)
        {
            var jagged = new int[rows][];
            var rubickNumbers = 1;

            for (int i = 0; i < rows; i++)
            {
                jagged[i] = new int[columns];
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    jagged[row][col] = rubickNumbers;
                    rubickNumbers++;
                }
            }

            return jagged;
        }
    }
}
