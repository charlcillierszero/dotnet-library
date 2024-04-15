namespace Results.Base.Errors;

public interface IError
{
    string Details { get; }

    List<string> Errors { get; }

    ErrorType ErrorType { get; }
}
