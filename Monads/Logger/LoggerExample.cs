namespace Monads.Logger;

public sealed class LoggerExample
{
    public static void RunExample()
    {
        var someValue = 5L;
        var endLogger = someValue
            .WrapWithLogger([])
            .Execute(TransformNumberToString, "Transform number 5 to string 5")
            .Execute(AppendToString, "Append '- appended' to the current string")
            .Execute(AppendToStringWithoutLog)
            .Execute(
                EmptyFunctionToAddExtraLog,
                "Adding extra log without transforming the data. The previous transformation appended a string without logging.");
        Console.WriteLine(endLogger.Item);
        Console.WriteLine(string.Join('\n', endLogger.Logs));
    }

    private static string TransformNumberToString(long num) => num.ToString();

    private static string AppendToString(string str) => str + " - appended";

    private static string AppendToStringWithoutLog(string str) => str + " - appended (without log)";

    private static T EmptyFunctionToAddExtraLog<T>(T value) => value;
}
