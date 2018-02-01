using System;
using System.Linq;

namespace _03._2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];
            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var inputMatrix = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputMatrix[col];
                }
            }
            var count = 0;
            for (int row = 1; row < matrix.GetLength(0) ; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row,col] == matrix[row - 1,col] && 
                        matrix[row,col] == matrix[row - 1, col + 1] &&
                        matrix[row,col] == matrix[row, col + 1]
                        )
                    {
                        count++;
                    }
                }                
            }
            Console.WriteLine(count);
        }
    }
}
