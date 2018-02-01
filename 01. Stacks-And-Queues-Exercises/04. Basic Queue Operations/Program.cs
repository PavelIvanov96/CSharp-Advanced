using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = tokens[0];
            var s = tokens[1];
            var x = tokens[2];

            var queueInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(queueInput[i]);
            }
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if(queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }

        }
    }
}
