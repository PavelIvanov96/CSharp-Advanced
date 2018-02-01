using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];
            var number = 1;

            var matrix = new List<List<int>>();

            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(number++);                    
                }
            }
             
            while (true)
            {                
                var cmd = Console.ReadLine();
                if (cmd == "Nuke it from orbit")
                {
                    break;
                }
                var tokens = cmd.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                var rowCommand = tokens[0];
                var colCommand = tokens[1];
                var radiusCom = tokens[1];              

                for (int row = 0; row < matrix.Count; row++)
                {
                    for (int col = 0; col < matrix[row].Count; col++)
                    {
                        if (row == rowCommand && col == colCommand)
                        {
                            if (col >= Math.Max(colCommand - radiusCom, 0) &&
                              col <=  Math.Min(colCommand + radiusCom, matrix[row].Count - 1))
                            {                                
                                matrix[row].RemoveAt(col);
                            }
                        }
                    }
                }                
            }
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
