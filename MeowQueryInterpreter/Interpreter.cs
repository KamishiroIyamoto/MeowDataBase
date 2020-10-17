using System;

namespace MeowQueryInterpreter
{
    internal static class Interpreter
    {
        //Класс интерпретатора MDB
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
