using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Event.Horizon.Operations.Resulting;

/// <summary>
/// That defines a error result
/// </summary>
[DataContract]
public readonly struct Error
{
    #region Fields

    /// <summary>
    /// Identifier error code
    /// </summary>
    [DataMember, JsonPropertyName("code")]
    public string Code { get; }

    /// <summary>
    /// Error type
    /// </summary>
    [DataMember, JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ErrorType Type { get; }

    /// <summary>
    /// A description error
    /// </summary>
    [DataMember, JsonPropertyName("message")]
    public string Message { get; }

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="code">Error code</param>
    /// <param name="message">Error message details</param>
    /// <param name="type">Error type</param>
    /// <exception cref="ArgumentNullException"></exception>
    public Error(string code, string message, ErrorType type = ErrorType.BusinessError)
    {
        Type = type;
        Code = string.IsNullOrWhiteSpace(code) ? throw new ArgumentNullException(nameof(code)) : code;
        Message = string.IsNullOrWhiteSpace(message) ? throw new ArgumentNullException(nameof(message)) : message;
    }

    #endregion
}