namespace MeowQueryInterpreter
{
    internal static class QueryHandler
    {
        //Класс обработки запросов
        public static void ConsoleQueryHandler()
        {
            string Query = System.Console.ReadLine();
            string[] Tokens = SyntaxAnalysys.Analyser(Query);

            switch (Tokens[0])
            {
                case "NULL":    System.Console.WriteLine("OK"); break;
                case "Take":    /*Что-то делает*/ break;
                case "Record":  /*Что-то делает*/ break;
            }
        }

        public static void FileQueryHandler(string FilePath)
        {
            //Что-то
        }
    }
}
