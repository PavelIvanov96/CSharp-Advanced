using System;
using System.Linq;

namespace _04._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var rows = tokens[0];
            var cols = tokens[1];
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            var maxSum = int.MinValue;
            var rowIndex = 0;
            var colIndex = 0;

            for (int row = 2; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                   
                    var currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row - 1, col] + matrix[row - 1, col + 1] + matrix[row - 1, col + 2] +
                        matrix[row - 2, col] + matrix[row - 2, col + 1] + matrix[row - 2, col + 2]; ;
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowIndex = row - 2;
                        colIndex = col;
                    }
                }
            }
            Console.WriteLine("Sum = {0}",maxSum);
            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                for (int col = colIndex; col < colIndex + 3; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
