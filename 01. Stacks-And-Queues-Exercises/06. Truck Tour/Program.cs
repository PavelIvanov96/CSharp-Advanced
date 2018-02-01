using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                var pump = Console.ReadLine()
                    .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(pump);                            
                
            }
            for (int currentStart = 0; currentStart < n - 1; currentStart++)
            {
                int fuel = 0;
                bool isSolution = true;

                for (int pumpPassed = 0; pumpPassed < n; pumpPassed++)
                {
                    var currentPump = queue.Dequeue();
                    var pumpFuel = currentPump[0];
                    var nextPumpDistance = currentPump[1];

                    queue.Enqueue(currentPump);

                    fuel += currentPump[0] - nextPumpDistance;
                    if (fuel < 0)
                    {
                        currentStart += pumpPassed;
                        isSolution = false;
                        break;
                    }
                }
                if (isSolution)
                {
                    Console.WriteLine(currentStart);
                    Environment.Exit(0);
                }
            }
        }
    }
}
