namespace Monads.Option
{
    public class OptionExample
    {
        public static void RunExample()
        {
            var someValue = 5L;
            var option01 = someValue.WrapWithOption();
            var option02 = option01.Execute(TransformNumberToString);
            var option03 = option02.Execute(AppendToString);
            var option04 = option03.Execute(TransformToDefault);
            var option05 = someValue
                .WrapWithOption()
                .Execute(TransformNumberToString)
                .Execute(AppendToString)
                .Execute(TransformToDefault);

            Console.WriteLine(option01);
            Console.WriteLine(option02);
            Console.WriteLine(option03);
            Console.WriteLine(option04);
            Console.WriteLine(option05);
        }

        private static string TransformNumberToString(long num) => num.ToString();

        private static string AppendToString(string str) => str + " - appended";

        private static T? TransformToDefault<T>(T item) => default;
    }
}
