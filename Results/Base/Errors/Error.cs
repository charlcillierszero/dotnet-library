namespace Results.Base.Errors;

public sealed class Error : IError
{
    public string Details { get; }

    public List<string> Errors { get; }

    public ErrorType ErrorType => ErrorType.Error;

    public Error(string details)
    {
        Details = details;
        Errors = [];
    }

    public Error(string details, string error)
    {
        Details = details;
        Errors = [error];
    }

    public Error(string details, List<string> errors)
    {
        Details = details;
        Errors = errors;
    }
}
