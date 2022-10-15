# Event Horizon Resulting Library ![resulting](https://github.com/lucasRafaell95/hrz-operations-resulting/actions/workflows/development-ci.yml/badge.svg)

This package contains a generic, extensible implementation of a base result class.

| Package                             |  Version         | Downloads       |
| ----------------------------------- | ---------------- | --------------- |
| `EventHorizon.Operations.Resulting` | [![NuGet](https://img.shields.io/nuget/v/EventHorizon.Operations.Resulting.svg)](https://nuget.org/packages/EventHorizon.Operations.Resulting) | [![Nuget](https://img.shields.io/nuget/dt/EventHorizon.Operations.Resulting.svg)](https://nuget.org/packages/EventHorizon.Operations.Resulting) |


 ## Installation

 The EventHorizon.Operations.Resulting package is available on [Nuget](https://nuget.org/packages/EventHorizon.Operations.Resulting). You can use it in the following ways:

 - Package Manager
```
PM> NuGet\Install-Package EventHorizon.Operations.Resulting -Version 1.0.0
```

 - .NET Cli
```
dotnet add package EventHorizon.Operations.Resulting --version 1.0.0
```

 - PackageReference
```
<PackageReference Include="EventHorizon.Operations.Resulting" Version="1.0.0" />
```

 ## How to use

 - Result

 Result was developed to encompass the result of operations in a generic and extensible way. With it it is possible to return from these literal types, such as an int for example, to complex objects.
 ```C#
 public Result<string> GetFullName(string firstName, string lastName)
 {
    var fullName = firstName + lastName;

    return new Result<string>(fullName);
 }
 ```

 - Error

 It is also possible to specify an error object to signal/return the status of an operation. Essentially, an error has two properties: code and a message. To use it, just do as in the example below:
 ```C#
 public Result<float> DivideNumber(float dividend, float divisor)
 {
    if(divisor <= 0)
    {
        var error = new Error("400-1", "You can never divide by zero");

        return new Result<float>(error);
    }

    var result = dividend / divisor;

    return new Result<float>(result);
 }
 ```

The Result contains the ```WithError()``` extension method that encapsulates the error creation logic. To use it, just do as in the following example:
 ```C#
public Result<string> GetFullName(string firstName, string lastName)
{
    var result = new Result<string>();

    if(string.IsNullOrEmpty(firstName))
	{
        return result.WithError("400-1", "Invalid first name");
	}

    if(string.IsNullOrEmpty(lastName))
	{
        return result.WithError("400-2", "Invalid last name");
	}

    result = firstName + lastName;

    return result;
}
 ```