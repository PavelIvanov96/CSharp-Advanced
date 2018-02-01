using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = 1080;
            test %= 360;

            while (test < 0)
            {
                test += 360;
            }
            Console.WriteLine(test);
        }
    }
}
