using System.Collections.Generic;

namespace MeowQueryInterpreter
{
    internal static class SyntaxAnalysys
    {
        /// <summary>Создание токенов строки кода</summary>
        /// <returns>Массив лексем</returns>
        private static string[] TokenBuilder(string CodeLine)
        {
            if (CodeLine.Length == 0)
                return new string[] {};

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
            System.Predicate<string> Predicate = Check;
            Tokens.RemoveAll(Predicate);

            return Tokens.ToArray();
        }

        /// <summary>
        /// Анализатор запрашиваемых данных
        /// </summary>
        /// <returns>Вид лексемы</returns>
        private static string SelectDataAnalysys(string Data)
        {
            if (Data[0] == SpecialLexems.ID_Operator)
                return SpecialLexems.ID_Select;
            else if (Data[0] == SpecialLexems.LBSeparator && Data[Data.Length - 1] == SpecialLexems.RBSeparator)
            {

                int RCount = 0, IdentificatorCount = TokenBuilder(Data.Substring(1, Data.Length - 1)).Length;
                for (int i = 1; i < Data.Length - 2; i++)
                    if (Data[i] == SpecialLexems.CommaSeparator) RCount++;

                if (RCount == IdentificatorCount)
                    return SpecialLexems.Data_Select;
            }
            else if (Data == SpecialLexems.All_Keyword)
                return SpecialLexems.All_Select;

            return Errors.FormatError;
        }

        /// <summary>
        /// Анализатор строки запроса
        /// </summary>
        public static void Analysys(string CodeLine)
        {
            string[] Tokens = TokenBuilder(CodeLine);
            if (Tokens.Length < 4) return;
        }
    }
}
