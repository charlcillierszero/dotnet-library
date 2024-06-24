namespace Monads.Promise;

public sealed class Promise<T>(Task<T> task, CancellationToken cancellationToken = default)
{
    public Task<T> Task { get; set; } = task;

    public CancellationToken CancellationToken { get; set; } = cancellationToken;
}

public static class PromiseExtensions
{
    public static Promise<T> MakePromise<T>(this Task<T> task, CancellationToken cancellationToken = default)
        => new(task, cancellationToken);

    public static Promise<U> Next<T, U>(this Promise<T> promise, Func<T, Task<U>> next)
    {
        var newTask = promise.Task.ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                return Task.FromException<U>(t.Exception.InnerException);
            }
            else if (t.IsCanceled)
            {
                return Task.FromCanceled<U>(promise.CancellationToken);
            }

            return next(t.Result);
        }).Unwrap();

        return newTask.MakePromise(promise.CancellationToken);
    }

    public static Promise<U> Next<T, U>(this Promise<T> promise, Func<Task<U>> next)
    {
        var newTask = promise.Task.ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                return Task.FromException<U>(t.Exception.InnerException);
            }
            else if (t.IsCanceled)
            {
                return Task.FromCanceled<U>(promise.CancellationToken);
            }

            return next();
        }).Unwrap();

        return newTask.MakePromise(promise.CancellationToken);
    }
}
