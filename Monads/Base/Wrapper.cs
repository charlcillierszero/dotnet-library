namespace Monads.Base
{
    public class Wrapper<T>(T item)
    {
        public T Item { get; } = item;
    }

    public static class WrapperExtention
    {
        public static Wrapper<T> Wrap<T>(this T item) => new(item);

        public static Wrapper<U> Execute<T, U>(this Wrapper<T> wrapped, Func<T, U> transform)
            => transform(wrapped.Item).Wrap();
    }
}
