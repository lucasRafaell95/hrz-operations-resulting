namespace Event.Horizon.Operations.Resulting.Extensions;

/// <summary>
/// Operation result extensions methods
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Extension method for creating result containing error
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="result">Result that will be extended</param>
    /// <param name="code">Error code</param>
    /// <param name="message">Error message</param>
    /// <param name="type">Error type</param>
    /// <returns></returns>
    public static Result<TResult> WithError<TResult>(this Result<TResult> result, string code, string message, ErrorType type = ErrorType.BusinessError)
    {
        result = new Error(code, message, type);

        return result;
    }
}