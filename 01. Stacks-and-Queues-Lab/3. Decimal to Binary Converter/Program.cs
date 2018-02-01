using System;
using System.Collections.Generic;

namespace _3._Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            if (inputNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }
            while (inputNumber > 0)
            {
                stack.Push(inputNumber % 2);
                inputNumber = inputNumber / 2;              
            }

            while(stack.Count != 0)
            { 
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
