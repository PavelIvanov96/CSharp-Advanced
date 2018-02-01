using System;
using System.Linq;
using System.Text;

namespace _07._Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());           

            var matrixA = GetMatrix(rows);
            var matrixB = GetMatrix(rows);
            var totalCount = GetMatrixRowsCount(matrixA, matrixB);

            if (totalCount > 0)
            {
                Console.WriteLine($"The total number of cells is: {totalCount}");
            }
            else
            {
                PrintMatrix(GetJoinedMatri(matrixA, matrixB));
            }
         
        }

        private static void PrintMatrix(int[][] matrix)
        {
            var stringBuilder = new StringBuilder();
            for (int row = 0; row < matrix.Length; row++)
            {
                stringBuilder.Append("[");
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    stringBuilder.Append(matrix[row][col]);
                    if (col == matrix[row].Length - 1)
                    {
                        stringBuilder.Append("]");
                    }
                    else
                    {
                        stringBuilder.Append(", ");
                    }
                }
                stringBuilder.AppendLine();
            }
            Console.WriteLine(stringBuilder);
        }

        private static int[][] GetJoinedMatri(int[][] matrixA, int[][] matrixB)
        {
            var rows = matrixA.Length;
            var joinedMatrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                joinedMatrix[row] = matrixA[row].Concat(matrixB[row].Reverse()).ToArray();
            }
            return joinedMatrix;
        }

        private static int[][] GetMatrix(int rows)
        {
            var jagged = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                jagged[row] = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }
            return jagged;
        }

        private static long GetMatrixRowsCount(int[][] matrixA ,int[][] matrixB)
        {
            var currentLength = matrixA[0].Length + matrixB[0].Length;
            var totalCount = currentLength;
            bool isValid = true;

            for (int i = 1; i < matrixA.Length; i++)
            {
                var currentRowCount = matrixA[i].Length + matrixB[i].Length;
                totalCount += currentRowCount;

                if (currentRowCount != currentLength)
                {
                    isValid = false;
                }                
            }
            if (isValid)
            {
                return 0;
            }
            return totalCount;
        }
    }
}
