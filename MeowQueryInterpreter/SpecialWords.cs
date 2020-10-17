namespace MeowQueryInterpreter
{
    internal static class SpecialWords
    {
        public static string SelectOperator { get; private set; } = "Take";
        public static string RecordOperator { get; private set; } = "Record";
        public static string PickUpKeyword  { get; private set; } = "From";
        public static string WriteKeyword   { get; private set; } = "To";

        public static string SelectData     { get; private set; } = "Data";
        public static string DB_Name        { get; private set; } = "DB_Name";

        public static string StringType     { get; private set; } = "String";
        public static string IntegerType    { get; private set; } = "Integer";
        public static string FloatType      { get; private set; } = "Float";
        public static string DateType       { get; private set; } = "Date";
    }
}
