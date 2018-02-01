using System;
using System.Linq;

namespace _02._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndColumns = Console.ReadLine()
               .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var rows = rowsAndColumns[0];
            var cols = rowsAndColumns[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var arrayRow = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arrayRow[col];
                }
            }
            int sum = 0;
            int rowIndex = 0, columnIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                  var  tempSum = matrix[row, col] + matrix[row , col + 1]
                        + matrix[row + 1, col ] + matrix[row + 1, col + 1];

                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowIndex = row;
                        columnIndex = col;
                    }
                }
            }
            Console.WriteLine(matrix[rowIndex, columnIndex] + " " + matrix[rowIndex, columnIndex + 1]);
            Console.WriteLine(matrix[rowIndex + 1,columnIndex] + " " + matrix[rowIndex + 1 , columnIndex + 1]);
            Console.WriteLine(sum);
        }
    }
}
