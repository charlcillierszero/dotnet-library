namespace Monads.Promise
{
    public class PromiseExample
    {
        public static void RunExample()
        {
            var task = WaitTotalSecondsAsync(0);
            var task2 = task
                .MakePromise()
                .Next(WaitTotalSecondsAsync)
                .Next(WaitTotalSecondsAsync)
                .Next(WaitTotalSecondsAsync);

            Console.WriteLine("Starting counting...");

            task2.Task.Wait();
            Console.WriteLine(task2.Task.Result);
        }

        private static Task<int> WaitTotalSecondsAsync(int seconds = 0)
        {
            seconds++;
            Task.Delay(seconds * 1_000).Wait();
            Console.WriteLine($"Waited {seconds} seconds.");
            return Task.FromResult(seconds);
        }
    }

}
