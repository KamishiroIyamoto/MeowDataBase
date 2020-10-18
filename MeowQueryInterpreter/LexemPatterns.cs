namespace MeowQueryInterpreter
{
    internal static class LexemPatterns
    {
        public static string[] ID_Selector { get; private set; } =
            {SpecialLexems.SelectOperator, SpecialLexems.ID_Select, SpecialLexems.Data_Select, SpecialLexems.PickUpKeyword, SpecialLexems.DataBaseName};

        public static string[] Field_Selector { get; private set; } =
            {SpecialLexems.SelectOperator, SpecialLexems.Data_Select, SpecialLexems.PickUpKeyword, SpecialLexems.DataBaseName};

        public static string[] All_Selector { get; private set; } =
            {SpecialLexems.SelectOperator, SpecialLexems.All_Select, SpecialLexems.PickUpKeyword, SpecialLexems.DataBaseName};

        public static string[] Field_Record { get; private set; } =
            {SpecialLexems.RecordOperator, SpecialLexems.Data_Select, SpecialLexems.WriteKeyword, SpecialLexems.DataBaseName};
    }
}
