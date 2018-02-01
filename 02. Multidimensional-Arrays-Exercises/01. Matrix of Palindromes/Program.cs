using System;
using System.Linq;

namespace _01._Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rows = indexes[0];
            var columns = indexes[1];

            string[,] matrix = new string[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = ((char)(97 + row)).ToString() + 
                        ((char)(97 + row + col)).ToString() +
                        ((char)(97 + row)).ToString();
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write((matrix[row,col]) +" ");
                }
                Console.WriteLine();
            }            
        }
    }
}
