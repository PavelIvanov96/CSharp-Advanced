using System;
using System.Collections.Generic;

namespace _01._Reversed_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            var bofer = input.ToCharArray();

            foreach (var item in bofer)
            {
                stack.Push(item);
            }
            foreach (var item in stack)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
