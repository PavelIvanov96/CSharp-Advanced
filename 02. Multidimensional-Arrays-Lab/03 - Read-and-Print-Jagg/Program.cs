using System;
using System.Linq;

namespace _3._Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int rowsCounter = 0; rowsCounter < rows; rowsCounter++)
            {
                jaggedArray[rowsCounter] = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            }

            for (int rowsCounter = 0; rowsCounter < jaggedArray.Length; rowsCounter++)
            {
                var row = jaggedArray[rowsCounter];
                for (int columnCounter = 0; columnCounter < row.Length; columnCounter++)
                {
                    Console.Write(row[columnCounter] + " ");
                    // Console.Write(jaggedArray[rowsCounter][columnCounter]);
                }
                Console.WriteLine();
            }
        }
    }
}
