using System;
using System.Collections.Generic;

namespace _09._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var stack = new Stack<long>(1);
            
            stack.Push(1);
            stack.Push(1);

            for (int i = 3; i <= n; i++)
            {
                var firstN = stack.Pop();
                var secondN = stack.Peek();
                stack.Push(firstN);

                var result = firstN + secondN;
                stack.Push(result);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
