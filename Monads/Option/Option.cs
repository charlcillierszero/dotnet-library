namespace Monads.Option;

public sealed class Option<T>(T value, bool hasValue)
{
    public T Item { get; private set; } = value;

    public bool HasValue { get; private set; } = hasValue;

    public override string ToString() => HasValue ? Item.ToString() : "None";
}

public static class OptionExtentions
{
    public static Option<T> Some<T>(T value) => new(value, true);

    public static Option<T> None<T>() => new(default, false);

    public static Option<T> WrapWithOption<T>(this T item) => item is not null ? Some(item) : None<T>();

    public static Option<U> Execute<T, U>(this Option<T> option, Func<T, U> transform)
        => option.HasValue ? transform(option.Item).WrapWithOption() : None<U>();
}
