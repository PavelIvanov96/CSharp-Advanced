using System;
using System.Collections.Generic;

namespace _5.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var count = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();

            foreach (var item in input)
            {
                queue.Enqueue(item);
            }

            while (queue.Count > 1)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }
                Console.WriteLine("Removed {0}", queue.Dequeue());
            }
            Console.WriteLine("Last is {0}", queue.Dequeue());
        }
    }
}
