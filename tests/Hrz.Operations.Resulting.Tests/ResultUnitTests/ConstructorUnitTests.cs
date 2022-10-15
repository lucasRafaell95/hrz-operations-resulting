using Event.Horizon.Operations.Resulting;
using FluentAssertions;
using System;
using Xunit;

namespace Hrz.Operations.Resulting.Tests.ResultUnitTests;

public sealed class ConstructorUnitTests
{
    [Fact]
    [Trait(nameof(Result<string>), "new(data)")]
    public void When_Result_Data_Is_Invalid_An_Argumentnullexception_Should_Be_Returned()
    {
        // arrange | act
        Action withDataNull = () => new Result<string>(data: default);

        // assert
        withDataNull
            .Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("data");
    }

    [Fact]
    [Trait(nameof(Result<string>), "new(data)")]
    public void When_The_Data_Entered_Is_Valid_A_Result_Must_Be_Created_With_The_Information_Provided()
    {
        // arrange
        string data = "result data";

        // act
        var result = new Result<string>(data);

        // assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Error.Should().BeNull();
        result.Data.Should().Be(data);
    }

    [Fact]
    [Trait(nameof(Result<string>), "new(error)")]
    public void When_A_Null_Error_Is_Passed_An_Argumentnullexception_Should_Be_Thrown()
    {
        // arrange | act
        Action withErrorNull = () => new Result<string>(error: default);

        // assert
        withErrorNull
            .Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("error");
    }

    [Fact]
    [Trait(nameof(Result<string>), "new(error)")]
    public void When_A_Valid_Error_Is_Passed_A_Result_Should_Be_Returned_With_A_List_Of_Errors()
    {
        // arrange
        Error error = new("400", "Error message");

        // act
        var result = new Result<string>(error);

        // assert
        result.Should().NotBeNull();
        result.Success.Should().BeFalse();
        result.Data.Should().BeNull();

        result.Error.Value.Code.Should().Be(error.Code);
        result.Error.Value.Message.Should().Be(error.Message);
    }
}