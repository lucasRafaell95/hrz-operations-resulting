using Event.Horizon.Operations.Resulting;
using Event.Horizon.Operations.Resulting.Extensions;
using FluentAssertions;
using System;
using Xunit;

namespace Hrz.Operations.Resulting.Tests.ExtensionsUnitTests;

public sealed class ResultExtensionsTests
{
    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [Trait(nameof(ResultExtensions.WithError), nameof(ResultExtensions.WithError))]
    public void When_An_Invalid_Code_Or_Message_Is_Informed_An_Argumentnullexception_Must_Be_Returned(string code, string message)
    {
        // arrange
        var result = new Result<string>();

        // act
        Func<Result<string>> withInvalidErrorCode = () => result.WithError(code, "error-message");
        Func<Result<string>> withInvalidErrorMessage = () => result.WithError("error-code", message);

        // assert
        withInvalidErrorCode
            .Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName(nameof(code));

        withInvalidErrorMessage
            .Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName(nameof(message));
    }

    [Fact]
    [Trait(nameof(ResultExtensions.WithError), nameof(ResultExtensions.WithError))]
    public void When_A_Valid_Code_Or_Message_Is_Informed_A_Result_Containing_An_Error_Must_Be_Returned()
    {
        // arrange
        var result = new Result<string>();

        // act
        result = result.WithError("error-code", "error-message");

        // assert
        result.Should().NotBeNull();
        result.Data.Should().BeNull();
        result.Error.Should().NotBeNull();

        result.Error.Value.Code.Should().Be("error-code");
        result.Error.Value.Message.Should().Be("error-message");
        result.Error.Value.Type.Should().Be(ErrorType.BusinessError);
    }
}