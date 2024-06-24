namespace Monads.Promise;

public sealed class PromiseExample
{
    public static void RunExample()
    {
        var promise = WaitTotalSecondsAsync(1)
            .MakePromise()
            .Next(data => WaitTotalSecondsAsync(++data))
            .Next(WaitTotalSecondsAsync)
            .Next(data => WaitTotalSecondsAsync(data + 2));

        Console.WriteLine("Starting counting...");

        promise.Task.Wait();

        Console.WriteLine(promise.Task.Result);
    }

    private static async Task<int> WaitTotalSecondsAsync(int seconds = 0)
    {
        await Task.Delay(seconds * 1_000);
        Console.WriteLine($"Waited {seconds} seconds.");
        return seconds;
    }
}
