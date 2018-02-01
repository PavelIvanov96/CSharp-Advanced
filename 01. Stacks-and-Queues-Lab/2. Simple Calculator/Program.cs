using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Reverse();
            var stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                var operat = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                switch (operat)
                {
                    case "+":
                        stack.Push((firstNumber + secondNumber).ToString());
                        break;
                    case "-":
                        stack.Push((firstNumber - secondNumber).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
