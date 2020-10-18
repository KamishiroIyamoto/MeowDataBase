namespace MeowQueryInterpreter
{
    public static class Interpreter
    {
        readonly static string Help = "Help Field";

        public static void Main(string[] args)
        {
            SyntaxAnalysys.Analysys("Take $[5] [word, int] From db.mdb");
            SyntaxAnalysys.Analysys("Take $[5][word, int] From db.mdb");
            SyntaxAnalysys.Analysys("Take [word, int] From db.mdb");
            SyntaxAnalysys.Analysys("Record [\"hello\", 24] To db.mdb");
            SyntaxAnalysys.Analysys("Record [\"hello\", 24,] To db.mdb");
            SyntaxAnalysys.Analysys("Record [\"hello\", 24] To db.mb");
            SyntaxAnalysys.Analysys("Take [\"hello\", 24,] To db.mb");
            SyntaxAnalysys.Analysys("Take [\"hello\", 24] To db.mdb");
        }
    }
}
