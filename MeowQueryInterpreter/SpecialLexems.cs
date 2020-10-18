namespace MeowQueryInterpreter
{
    internal static class SpecialLexems
    {
        public static string SelectOperator { get; private set; } = "Take";
        public static string RecordOperator { get; private set; } = "Record";
        public static string PickUpKeyword  { get; private set; } = "From";
        public static string WriteKeyword   { get; private set; } = "To";

        public static string StringType     { get; private set; } = "String";
        public static string IntegerType    { get; private set; } = "Integer";
        public static string FloatType      { get; private set; } = "Float";
        public static string DateType       { get; private set; } = "Date";

        public static string ID_Select      { get; private set; } = "ID_Select";
        public static string Data_Select    { get; private set; } = "Data_Select";
        public static string All_Select     { get; private set; } = "All_Select";
        public static string All_Keyword    { get; private set; } = "ALL";
        public static string DataBaseName   { get; private set; } = "DataBaseName";


        public static char   ID_Operator    { get; private set; } = '$';
        public static char   CommaSeparator { get; private set; } = ',';
        public static char   LBSeparator    { get; private set; } = '[';
        public static char   RBSeparator    { get; private set; } = ']';

        public static string CorrectSyntax  { get; private set; } = "CorrectSyntax";
    }
}
