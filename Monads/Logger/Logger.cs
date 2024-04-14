namespace Monads.Logger
{
    public class Logger<T>(T item, List<string> logs)
    {
        public T Item { get; } = item;

        public List<string> Logs { get; } = logs;
    }

    public static class LoggerExtensions
    {
        public static Logger<T> WrapWithLogger<T>(this T item, List<string> logs) => new(item, logs);

        public static Logger<U> Execute<T, U>(this Logger<T> logger, Func<T, U> transform, string? log = null)
        {
            if (!string.IsNullOrEmpty(log))
            {
                logger.Logs.Add(log);
            }

            return transform(logger.Item).WrapWithLogger(logger.Logs);
        }
    }
}
