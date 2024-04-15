namespace Monads.Promise;

public sealed class Promise<T>(Task<T> task)
{
    public Task<T> Task { get; set; } = task;
}

public static class PromiseExtensions
{
    public static Promise<T> MakePromise<T>(this Task<T> task) => new(task);

    public static Promise<U> Next<T, U>(this Promise<T> promise, Func<T, Task<U>> next)
    {
        promise.Task.Wait();
        var awaitedTask = promise.Task.Result;
        return next(awaitedTask).MakePromise();
    }
}
