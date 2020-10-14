#define TESTS
using System;
using System.Collections.Generic;
#if TESTS
using System.IO;
#endif

namespace CheckBrackets
{
    struct Bracket
    {
        public char Type { get; }
        public int Position { get; }

        public Bracket(char type, int position)
        {
            Type = type;
            Position = position;
        }

        public bool Matchc(char c)
        {
            if (Type == '[' && c == ']')
                return true;
            if (Type == '{' && c == '}')
                return true;
            if (Type == '(' && c == ')')
                return true;
            return false;
        }
    }
    class CheckBrackets
    {
#if TESTS
        public static void RunTests()
        {
            var files = Directory.GetFiles("tests", @"", SearchOption.TopDirectoryOnly);

            for (int i = 0, j = 1; i < files.Length; i += 2, j++)
            {
                using (var sr = new StreamReader(files[i]))
                {
                    var text = sr.ReadToEnd().Trim();
                    var result = checkBrackets(text);
                    using (var sr1 = new StreamReader(files[i + 1]))
                    {
                        if (result.Count == 0)
                        {
                            Console.WriteLine($"File:{j}, Actual = Success, Expected = {sr1.ReadToEnd().Trim()}");
                        }
                        else
                        {
                            Console.WriteLine($"File:{j}, Actual = {result.Peek().Position}, Expected = {sr1.ReadToEnd().Trim()}");
                        }
                    }
                }
            }
        }
#endif

        private static Stack<Bracket> checkBrackets(string text)
        {
            var openingBracketsStack = new Stack<Bracket>();
            for (var position = 0; position < text.Length; ++position)
            {
                var next = text[position];
                if (next == '(' || next == '[' || next == '{')
                {
                    // Process opening bracket, write your code here
                    openingBracketsStack.Push(new Bracket(next, position + 1));
                }

                if (next == ')' || next == ']' || next == '}')
                {
                    // Process closing bracket, write your code here
                    if (openingBracketsStack.Count != 0 && openingBracketsStack.Peek().Matchc(next))
                        openingBracketsStack.Pop();
                    else
                    {
                        openingBracketsStack.Push(new Bracket(next, position + 1));
                        break;
                    }
                }
            }
            return openingBracketsStack;
        }

        static void Main(string[] args)
        {
#if TESTS
            RunTests();
#else
            var text = Console.ReadLine();
            var result = checkBrackets(text);

            if (result.Count == 0)
                Console.WriteLine("Success");
            else
                Console.WriteLine(result.Peek().Position);
#endif
        }

    }
}
