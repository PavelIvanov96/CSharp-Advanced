using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12._String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Trim();
            var degrees = int.Parse(command.Substring(7).Trim(')'));
            var commandDegrees = GetRotationDegrees(degrees);

            var matrix = GetMatrix();
            switch (commandDegrees)
            {
                case 0:
                    PrintRotatedMatrix0(matrix);
                    break;
                case 90:
                    PrintRotatedMatrix90(matrix);
                    break;
                case 180:
                    PrintRotatedMatrix180(matrix);
                    break;
                case 270:
                    PrintRotatedMatrix270(matrix);
                    break;                    
            }

            
        //    Console.WriteLine("Standart");
        //    for (int row = 0; row < matrix.Length; row++)
        //    {
        //        for (int col = 0; col < matrix[row].Length; col++)
        //        {
        //            Console.Write(matrix[row][col]);
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine("Test 270");
        //    for (int row = matrix[0].Length - 1; row >= 0; row--)
        //    {
        //        for (int col = 0; col < matrix.Length; col++)
        //        {
        //            Console.Write(matrix[col][row]);
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine("Test 90");
        //    for (int row = 0; row < matrix[0].Length; row++)
        //    {
        //        for (int col = matrix.Length - 1; col >= 0; col--)
        //        {
        //            Console.Write(matrix[col][row]);
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine("Test 180");
        //    for (int row = matrix.Length - 1; row >= 0; row--)
        //    {            
        //        Console.WriteLine(string.Join("",matrix[row].Reverse()));
        //    }
        }

        private static void PrintRotatedMatrix270(char[][] matrix)
        {
            for (int row = matrix[0].Length - 1; row >= 0; row--)
            {
                for (int col = 0; col < matrix.Length; col++)
                {
                    Console.Write(matrix[col][row]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintRotatedMatrix180(char[][] matrix)
        {
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                Console.WriteLine(string.Join("", matrix[row].Reverse()));
            }
        }

        private static void PrintRotatedMatrix90(char[][] matrix)
        {
            for (int row = 0; row < matrix[0].Length; row++)
            {
                for (int col = matrix.Length - 1; col >= 0; col--)
                {
                    Console.Write(matrix[col][row]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintRotatedMatrix0(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static object GetRotationDegrees(int degrees)
        {
            degrees %= 360;

            while (degrees < 0)
            {
                degrees += 360;
            }
            return degrees;
        }

        private static char[][] GetMatrix()
        {
            var txt = new List<string>();

            while (true)
            {
                var tokens = Console.ReadLine();

                if (tokens == "END")
                {
                    break; 
                }
                txt.Add(tokens);                
            }
            var rows = txt.Count;
            var colums = txt.Select(x => x.Count()).Max();

            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var builder = new StringBuilder(txt[row]);
                builder.Append(new string(' ', colums - txt[row].Length));
                matrix[row] = builder.ToString().ToCharArray();
            }
            return matrix;
        }
    }
}
