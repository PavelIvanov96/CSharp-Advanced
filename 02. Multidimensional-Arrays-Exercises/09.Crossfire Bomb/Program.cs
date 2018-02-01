using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Crossfire_Bomb
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArgs = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int n = inputArgs[0];
            int m = inputArgs[1];

            List <List<int>> matrix = new List<List<int>>();
            FillMatrix(matrix, n, m);

            while (true)
            {
                var token = Console.ReadLine();
                if (token == "Nuke it from orbit")
                {
                    break;
                }

                var command = token.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int row = command[0];
                int col = command[1];
                int radius = command[2];
                BombMatrix(matrix, row, col, radius);

                RearrangeMatrix(matrix);
            }
            PrintMatrix(matrix);
        }

        private static void RearrangeMatrix(List<List<int>> matrix)
        {
            for (int r = 0; r < matrix.Count; r++)
            {
                var currentRowValues = matrix[r].Where(n => n > 0).ToList();

                if (currentRowValues.Count > 0)
                {
                    currentRowValues.RemoveAll(n => n == 0);
                    matrix[r] = currentRowValues;
                }
                else
                {
                    matrix.RemoveAt(r);
                    r--;
                }
            }
        }

        private static void BombMatrix(List<List<int>> matrix, int row, int col, int radius)
        {
            int targetRow = row;
            int targetCol = col;
            int radiuss = radius;

            if (targetRow >= 0 && targetRow < matrix.Count)
            {
                for (int coll = Math.Max(0, targetCol - radiuss); coll <= Math.Min(targetCol + radiuss, matrix[targetRow].Count - 1); coll++)
                {                    
                     matrix[targetRow][coll] = 0;                    
                }
            }

            if (targetCol >= 0 && targetCol < matrix[0].Count)
            {
                for (int roww = Math.Max(0, targetRow - radiuss); roww <= Math.Min(targetRow + radiuss, matrix.Count - 1); roww++)
                {
                    if (targetCol < matrix[roww].Count)
                    {
                        matrix[roww][targetCol] = 0;
                    }
                }
            }
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var r in matrix)
            {
                Console.WriteLine(string.Join(" ",r));
            }
        }

        private static void FillMatrix(List<List<int>> matrix, int n, int m)
        {
            int counter = 1;

            for (int r = 0; r < n; r++)
            {
                matrix.Add(new List<int>());
                for (int c = 0; c < m; c++)
                {
                    matrix[r].Add(counter);
                    counter++;
                }
            }                
        }
    }
}
