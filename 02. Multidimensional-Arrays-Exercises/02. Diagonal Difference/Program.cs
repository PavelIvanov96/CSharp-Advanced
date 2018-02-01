using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowCol = int.Parse(Console.ReadLine());

            var matrix = new double[rowCol, rowCol];

            for (int row = 0; row < rowCol; row++)
            {
                var matrixNumbers = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
                for (int col = 0; col < rowCol; col++)
                {
                    matrix[row, col] = matrixNumbers[col];
                }                
            }
            var sumFirstDiagonal = 0.0;
            var sumSecondDiagonal = 0.0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == row)
                    {
                        sumFirstDiagonal += matrix[row, col];
                    }
                    
                }
                sumSecondDiagonal += matrix[row, rowCol - row - 1];
            }
            Console.WriteLine(Math.Abs(sumFirstDiagonal - sumSecondDiagonal));            
        }
    }
}
