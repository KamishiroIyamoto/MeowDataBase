using System.Collections.Generic;

namespace MeowQueryInterpreter
{
    internal static class SyntaxAnalysys
    {
        //Класс синтаксического анализа запросов

        /// <summary>Создание токенов строки кода</summary>
        /// <returns>Массив лексем</returns>
        private static string[] TokenBuilder(string CodeLine)
        {
            List<string> Tokens = new List<string>();
            string Temp = "";
            foreach (char Symbol in CodeLine)
            {
                if (Symbol == ' ' && Temp != "")
                {
                    Tokens.Add(Temp);
                    Temp = "";
                }
                else if (Symbol == ' ' && Temp == "")
                    continue;
                else if (Symbol == '\t')
                    continue;
                else
                    Temp += Symbol;
            }
            Tokens.Add(Temp);

            bool Check(string str) => str == "" || str == " ";
            System.Predicate<string> predicate = Check;
            Tokens.RemoveAll(predicate);

            return Tokens.ToArray();
        }


    }
}
