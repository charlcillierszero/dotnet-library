namespace Results.Base.Errors;

public sealed class NotFoundError : IError
{
    public string Details { get; }

    public List<string> Errors { get; }

    public ErrorType ErrorType => ErrorType.Error;

    public NotFoundError(string details)
    {
        Details = details;
        Errors = [];
    }

    public NotFoundError(string details, string error)
    {
        Details = details;
        Errors = [error];
    }

    public NotFoundError(string details, List<string> errors)
    {
        Details = details;
        Errors = errors;
    }
}
