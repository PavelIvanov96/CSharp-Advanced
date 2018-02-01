using System;
using System.Linq;
using System.Text;

namespace _11._Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(new char[]  { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = tokens[0];
            var cols = tokens[1];
            var matrixChars = new StringBuilder();
            matrixChars.Append("x");
            for (int i = 0; i < cols - 1; i++)
            {
                matrixChars.Append("o");
            }

            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = matrixChars.ToString().ToCharArray();
            }

          // foreach (var item in matrix)
          // {
          //     Console.WriteLine(string.Join(" ",item));
          // }

            while (true)
            {
                var token = Console.ReadLine();
                if (token == "stop")
                {
                    break;
                }
                var commands = token.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                var entryRow = commands[0];
                var r = commands[1];
                var c = commands[2];

                bool haveSpaces = false;
                var indexOfRow = 0;
                var indexOfCol = 0;

                bool haveSpacesAfter = false;
                
                var indexOfAfterCol = 0;

                var isFull = false;
                var count = 1;
                var sum = Math.Abs(r - entryRow);
                count += sum;
                
                //Console.WriteLine(sum);

                for (int row = r; row < r + 1; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {                        
                        if (matrix[row][col] == 'o' && col < c)
                        {
                            haveSpaces = true;
                            indexOfRow = row;
                            indexOfCol = col;                            
                        }
                        if (matrix[row][c] == 'o')
                        {
                            matrix[row][c] = 'C';
                            count += c;
                            break;
                        }
                        if (haveSpaces == true)
                        {
                            if (matrix[row][c] == 'C')
                            {
                                for (int i = c; i > 0; i--)
                                {
                                    if (matrix[row][i] == 'o')
                                    {
                                        matrix[row][i] = 'C';
                                        count += i;
                                        break;
                                    }
                                }
                               // count += indexOfCol;
                               // break;
                            }
                        }
                        if(haveSpaces == false && col > c && matrix[row][c] == 'C')                                      
                        {
                            for (int i = c ; i < cols; i++)
                            {
                                if (matrix[row][i] == 'o')
                                {
                                    matrix[row][i] = 'C';
                                    indexOfAfterCol = i;
                                    haveSpacesAfter = true;                                   
                                    break;
                                }
                                if (matrix[row][cols - 1] == 'C')
                                {
                                    isFull = true;
                                }
                                
                            }
                        }                        
                        if (haveSpacesAfter)
                        {
                            count += indexOfAfterCol;
                            break;
                        }
                    }                    
                }
               // foreach (var item in matrix)
               // {
               //     Console.WriteLine(string.Join(" ",item));
               // }
                if (isFull == false)
                {
                    Console.WriteLine(count);
                }
                else
                {
                    Console.WriteLine("Row {0} full",r);
                }
            }            
        }
    }
}
