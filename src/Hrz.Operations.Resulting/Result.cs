using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Event.Horizon.Operations.Resulting;

/// <summary>
/// Represents a basic contract to return errors in 
/// a simple and extensible way
/// </summary>
/// <typeparam name="TResult"></typeparam>
[DataContract]
public readonly struct Result<TResult>
{
    /// <summary>
    /// Indicates the state of the returned result
    /// </summary>
    [DataMember, JsonPropertyName("success")]
    public bool Success { get => IsSuccess(); }

    /// <summary>
    /// Indicates the information that will be returned in the result
    /// </summary>
    [DataMember, JsonPropertyName("data")]
    public TResult? Data { get; }

    /// <summary>
    /// Contains erros details
    /// </summary>
    [DataMember, JsonPropertyName("error")]
    public Error? Error { get; }

    /// <summary>
    /// Default constructor. 
    /// </summary>
    public Result()
    {
        Data = default;
        Error = default;
    }

    /// <summary>
    /// Constructor to instantiate with success data valus. The error 
    /// will be null and property success true
    /// </summary>
    /// <param name="data">Result data value</param>
    /// <exception cref="ArgumentNullException"></exception>
    public Result(TResult? data)
    {
        Error = default;
        Data = data ?? throw new ArgumentNullException(nameof(data));
    }

    /// <summary>
    /// Constructor to instantiate with an error. In this case, data 
    /// will be null and the property success true
    /// </summary>
    /// <param name="error">Error object</param>
    /// <exception cref="ArgumentNullException"></exception>
    public Result(Error? error)
    {
        Data = default;
        Error = error ?? throw new ArgumentNullException(nameof(error));
    }

    /// <summary>
    /// Operator to create a result a sucess result with data
    /// </summary>
    /// <param name="data"></param>
    public static implicit operator Result<TResult>(TResult data)
        => new(data);

    /// <summary>
    /// Operator to create a result a failure result with error
    /// </summary>
    /// <param name="error"></param>
    public static implicit operator Result<TResult>(Error error)
        => new(error);

    private bool IsSuccess()
        => Error is null;
}