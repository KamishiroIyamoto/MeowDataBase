using System.Collections.Generic;

namespace MeowQueryInterpreter
{
    internal static class SyntaxAnalysys
    {
        /// <summary>Создание токенов строки кода</summary>
        /// <returns>Массив лексем</returns>
        private static string[] TokenBuilder(string CodeLine)
        {
            List<string> Tokens = new List<string>();

            string Temp = "";
            for (int i = 0; i < CodeLine.Length; i ++)
            {
                if (CodeLine[i] == SpecialLexems.ID_Operator && Temp == "")
                {
                    for (; i < CodeLine.Length && CodeLine[i] != SpecialLexems.RBSeparator; i++)
                        if (CodeLine[i] != ' ')
                            Temp += CodeLine[i];
                    Temp += SpecialLexems.RBSeparator;
                    Tokens.Add(Temp);
                    Temp = "";
                }
                else if (CodeLine[i] == SpecialLexems.LBSeparator && Temp == "")
                {
                    for (; i < CodeLine.Length && CodeLine[i] != SpecialLexems.RBSeparator; i++)
                        if (CodeLine[i] != ' ')
                            Temp += CodeLine[i];
                    Temp += SpecialLexems.RBSeparator;
                    Tokens.Add(Temp);
                    Temp = "";
                }
                else if (CodeLine[i] == ' ')
                {
                    Tokens.Add(Temp); 
                    Temp = "";
                }
                else
                    Temp += CodeLine[i];
            }
            Tokens.Add(Temp);

            static bool Check(string String) => String == "" || String == " ";
            System.Predicate<string> Predicate = Check;
            Tokens.RemoveAll(Predicate);

            return Tokens.ToArray();
        }

        /// <summary>
        /// Анализатор запроса
        /// </summary>
        /// <returns>Код состояния</returns>
        private static string CodeLineAnalysys(string[] CodeLineTokens)
        {
            List<string> CodeLinePattern = new List<string>();

            foreach (string Token in CodeLineTokens)
            {
                if (Token == SpecialLexems.SelectOperator)
                    CodeLinePattern.Add(SpecialLexems.SelectOperator);
                else if (Token == SpecialLexems.RecordOperator)
                    CodeLinePattern.Add(SpecialLexems.RecordOperator);
                else if (Token == SpecialLexems.PickUpKeyword)
                    CodeLinePattern.Add(SpecialLexems.PickUpKeyword);
                else if (Token == SpecialLexems.WriteKeyword)
                    CodeLinePattern.Add(SpecialLexems.WriteKeyword);
                else if (Token[0] == SpecialLexems.ID_Operator)
                    CodeLinePattern.Add(SpecialLexems.ID_Select);
                else if (Token[0] == SpecialLexems.LBSeparator && Token[^1] == SpecialLexems.RBSeparator)
                {
                    static int IdentificatorsCount(string CodeLine)
                    {
                        string[] Temp = CodeLine.Split(' ');
                        string TempStr = "";
                        foreach (string T in Temp)
                            TempStr += T;

                        List<string> Id = new List<string>(TempStr.Split(','));
                        static bool Check(string String) => String == "" || String == " ";
                        System.Predicate<string> Predicate = Check;
                        Id.RemoveAll(Predicate);
                        return Id.Count;
                    }

                    static int CommaCount(string CodeLine)
                    {
                        int Count = 0;
                        foreach (char Ch in CodeLine)
                            if (Ch == ',')
                                Count++;
                        return Count;
                    }

                    if (CommaCount(Token[1..^1]) == IdentificatorsCount(Token[1..^1]) - 1)
                        CodeLinePattern.Add(SpecialLexems.Data_Select);
                    else
                        return Errors.FormatError;
                }
                else if (Token.Length >= 5 && Token[^4..^0] == ".mdb")
                    CodeLinePattern.Add(SpecialLexems.DataBaseName);
                else
                    return Errors.FormatError;
            }

            if (CodeLinePattern.Count == 5)
            {
                for (int i = 0; i < 5; i++)
                    if (CodeLinePattern[i] != LexemPatterns.ID_Selector[i])
                        return Errors.SyntaxError;
                return SpecialLexems.CorrectSyntax;
            }
            else if (CodeLinePattern.Count == 4)
            {
                if (CodeLinePattern[0] == SpecialLexems.SelectOperator)
                {
                    for (int i = 0; i < 4; i++)
                        if (CodeLinePattern[i] != LexemPatterns.Field_Selector[i])
                            return Errors.SyntaxError;
                    return SpecialLexems.CorrectSyntax;
                }
                else if (CodeLinePattern[0] == SpecialLexems.RecordOperator)
                {
                    for (int i = 0; i < 4; i++)
                        if (CodeLinePattern[i] != LexemPatterns.Field_Record[i])
                            return Errors.SyntaxError;
                    return SpecialLexems.CorrectSyntax;
                }
            }
            return Errors.SyntaxError;
        }

        /// <summary>
        /// Анализатор строки запроса
        /// </summary>
        public static void Analysys(string CodeLine)
        {
            System.Console.WriteLine(CodeLineAnalysys(TokenBuilder(CodeLine)));
        }
    }
}
