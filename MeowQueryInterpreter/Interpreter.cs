namespace MeowQueryInterpreter
{
    public static class Interpreter
    {
        private static string Help = "Help Field";

        public static void Main(string[] args)
        {
            if (args.Length < 0)
            {
                System.Console.WriteLine(Help);
            }
        }
    }
}
