using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPlants = int.Parse(Console.ReadLine());            

            var plants = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Take(numberOfPlants)
                .ToArray();

            int days = 0;
            while (true)
            {
                bool deadPlants = false;
                var queue = new Queue<int>();
                queue.Enqueue(plants[0]);
                for (int i = 1; i < plants.Length; i++)
                {
                    if (plants[i - 1] >= plants[i])
                    {
                        queue.Enqueue(plants[i]);
                    }
                    else
                    {
                        deadPlants = true;
                    }                                      
                }
                if (!deadPlants)
                {                    
                    break;
                }
                days++;
                plants = queue.ToArray();
                queue.TrimExcess();
            }
            Console.WriteLine(days);
        }
    }
}
