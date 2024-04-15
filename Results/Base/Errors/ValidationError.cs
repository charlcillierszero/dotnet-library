namespace Results.Base.Errors;

public sealed class ValidationError : IError
{
    public string Details { get; }

    public List<string> Errors { get; }

    public ErrorType ErrorType => ErrorType.Error;

    public ValidationError(string details)
    {
        Details = details;
        Errors = [];
    }

    public ValidationError(string details, string validationError)
    {
        Details = details;
        Errors = [validationError];
    }

    public ValidationError(string details, List<string> validationErrors)
    {
        Details = details;
        Errors = validationErrors;
    }
}
