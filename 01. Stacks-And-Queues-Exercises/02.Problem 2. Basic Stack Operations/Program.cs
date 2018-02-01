using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Problem_2._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            var s = int.Parse(input[1]);
            var x = int.Parse(input[2]);

            var numbers = Console.ReadLine().Split(' ');

            var stack = new Stack<int>();
            var bound = Math.Min(numbers.Length, n);
            for (int i = 0; i < bound; i++)
            {
                stack.Push(int.Parse(numbers[i]));
            }
            for (int i = 0; i < s; i++)
            {
                if (stack.Count == 0)
                {
                    break;
                }
                stack.Pop();
            }
            
            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
             
            }

          //  Console.WriteLine("true");
        }
    }
}
