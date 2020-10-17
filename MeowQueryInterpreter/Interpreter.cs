namespace MeowQueryInterpreter
{
    internal static class Interpreter
    {
        private static string Help = "Help Field";

        public static void Main(string[] args)
        {
            if (args.Length < 0)
            {
                System.Console.WriteLine(Help);
            }
            else
            {
                switch (args[0])
                {
                    case "-cl": 
                        QueryHandler.ConsoleQueryHandler(); break;
                    case "-fl":
                        if (args.Length < 2)
                            System.Console.WriteLine(Help);
                        else
                            QueryHandler.FileQueryHandler(args[1]); 
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
