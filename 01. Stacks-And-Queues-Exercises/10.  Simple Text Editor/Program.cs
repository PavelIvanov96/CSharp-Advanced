using System;
using System.Collections.Generic;
using System.Text;

namespace _10.__Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            var text = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = int.Parse(input[0]);
                
                if (command == 1)
                {
                    if (input.Length > 1)
                    {
                        stack.Push(text.ToString());
                        text.Append(input[1]);
                    }
                }
                else if (command == 2)
                {
                    var length = int.Parse(input[1]);
                    stack.Push(text.ToString());

                    if (length > text.Length)
                    {
                        text.Clear();
                        break;
                    }
                    text.Remove(text.Length - length, length);

                }
                else if (command == 3)
                {
                    if (input.Length > 1)
                    {
                        var index = int.Parse(input[1]);
                        if (text.Length >= index && index > 0)
                        {
                            Console.WriteLine(text[index - 1]);
                        }                    
                    }
                }
                else if (command == 4)
                {
                    text.Clear();
                    text.Append(stack.Pop());
                }
            }
        }
    }
}
