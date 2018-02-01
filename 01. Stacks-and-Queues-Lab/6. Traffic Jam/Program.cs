using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var command = Console.ReadLine();
            var queue = new Queue<string>();
            var passedCount = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    var count = Math.Min(n, queue.Count);
                    for (int i = 0; i < count; i++)
                    {
                        passedCount++;
                        Console.WriteLine("{0} passed!",queue.Dequeue());                        
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("{0} cars passed the crossroads.",passedCount);
        }
    }
}
