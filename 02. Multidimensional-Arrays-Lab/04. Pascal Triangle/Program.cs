using System;

namespace _04._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var height = int.Parse(Console.ReadLine());

            long[][] pascal = new long[height][];

            for (long row = 0; row < height; row++)
            {
                pascal[row] = new long[row + 1];
                pascal[row][0] = 1;
                pascal[row][pascal[row].Length - 1] = 1;

                for (int col = 1; col < pascal[row].Length - 1; col++)
                {
                    pascal[row][col] = pascal[row - 1][col - 1] + pascal[row - 1][col];
                }
            }

            foreach (var item in pascal)
            {
                Console.WriteLine(String.Join(" ",item));
            }
            

             var debug = 0;
        }
    }
}
