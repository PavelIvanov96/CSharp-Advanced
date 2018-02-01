using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = double.Parse(Console.ReadLine().Trim());
            var queue = new Queue<double>();
            queue.Enqueue(n);
            Console.Write(n + " ");     
            for (int i = 0; i < 16; i++)
            {
                var quequeOperand = queue.Dequeue();
                var firstOperation = quequeOperand + 1;
                var secondOperation = 2 * quequeOperand + 1;
                var thirdOperation = quequeOperand + 2;
                queue.Enqueue(firstOperation);
                queue.Enqueue(secondOperation);
                queue.Enqueue(thirdOperation);
                Console.Write("{0} {1} {2} ",firstOperation,secondOperation,thirdOperation);                
            }
            Console.Write(queue.Dequeue() + 1);            
        }
    }
}
