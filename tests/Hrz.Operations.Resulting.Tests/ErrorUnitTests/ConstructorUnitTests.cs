using Event.Horizon.Operations.Resulting;
using FluentAssertions;
using System;
using Xunit;

namespace Hrz.Operations.Resulting.Tests.ErrorUnitTests;

public sealed class ConstructorUnitTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    public void When_An_Invalid_Parameter_Is_Informed_An_Argumentnullexception_Should_Be_Thrown(string? code, string? message)
    {
        // arrange | act
        Action withCodeNull = () => new Error(code, "message");
        Action withMessageNull = () => new Error("code", message);

        // assert
        withCodeNull
            .Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName(nameof(code));

        withMessageNull
            .Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName(nameof(message));
    }

    [Fact]
    [Trait(nameof(Error), "new()")]
    public void When_A_Valid_Code_And_Message_Is_Informed_An_Error_Must_Be_Created()
    {
        // arrange
        var code = "400";
        var message = "erro message";

        // act
        var error = new Error(code, message);

        // assert
        error.Should().NotBeNull();
        error.Code.Should().Be(code);
        error.Message.Should().Be(message);
        error.Type.Should().Be(ErrorType.BusinessError);
    }
}