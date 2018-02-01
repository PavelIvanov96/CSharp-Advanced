using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxNumbers = new Stack<int>();
            var maxValue = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var com = int.Parse(commands[0]);

                if (com == 1)
                {
                    stack.Push(int.Parse(commands[1]));
                    if (maxValue < int.Parse(commands[1]))
                    {
                        maxValue = int.Parse(commands[1]);
                        maxNumbers.Push(maxValue);
                    }
                }
                else if (com == 2)
                {

                    if (stack.Pop() == maxValue)
                    {
                        maxNumbers.Pop();
                        if (maxNumbers.Count() != 0)
                        {
                            maxValue = maxNumbers.Peek();
                        }
                        else
                        {
                            maxValue = int.MinValue;
                        }
                    }
                }
                else if (com == 3)
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine(0);
                    }
                    else
                    {
                        Console.WriteLine(maxValue);
                    }
                }
            }
        }
    }
}
