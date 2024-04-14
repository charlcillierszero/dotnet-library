using Monads.Base;
using Monads.Logger;
using Monads.Option;
using Monads.Promise;

namespace Monads
{
    public class Program()
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Executing Wrapper Example");
            WrapperExample.RunExample();
            Console.WriteLine();

            Console.WriteLine("Executing Logger Example");
            LoggerExample.RunExample();
            Console.WriteLine();

            Console.WriteLine("Executing Option Example");
            OptionExample.RunExample();
            Console.WriteLine();

            Console.WriteLine("Executing Promise Example");
            PromiseExample.RunExample();
            Console.WriteLine();
        }
    }
}