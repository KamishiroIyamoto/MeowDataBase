using System;

namespace MeowQueryInterpreter
{
    internal static class Interpreter
    {
        private static string Help = "Help Field";

        public static void Main(string[] args)
        {
            if (args.Length < 0)
            {
                Console.WriteLine(Help);
            }
            else
            {
                Console.WriteLine("Get arguments");
            }
        }
    }
}
