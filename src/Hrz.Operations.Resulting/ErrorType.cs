using System.ComponentModel;

namespace Event.Horizon.Operations.Resulting;

/// <summary>
/// Error type
/// </summary>
public enum ErrorType
{
    /// <summary>
    /// Request with incorrect/inconsistent data
    /// </summary>
    [Description("Business Error")]
    BusinessError = 1,

    /// <summary>
    /// Error while processing the request
    /// </summary>
    [Description("Server Error")]
    ServerError = 2
}