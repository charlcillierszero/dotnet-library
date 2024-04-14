namespace Monads.Base
{
    public class WrapperExample
    {
        public static void RunExample()
        {
            var someValue = 5L;
            var endResult = someValue
                .Wrap()
                .Execute(TransformNumberToString)
                .Execute(AppendToString)
                .Item;
            Console.WriteLine(endResult);
        }

        private static string TransformNumberToString(long num) => num.ToString();

        private static string AppendToString(string str) => str + " - appended";
    }
}
