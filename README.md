# RegularExpressionTestC-

A C# project demonstrating and testing custom error messages with the RegularExpression data annotation attribute.

## Project Description

This project tests that we can use custom error messages in C# using the `RegularExpression` annotation. It includes:

- A model class (`ArtifactType`) with validation attributes including a `RegularExpression` with a custom `ErrorMessage`
- Comprehensive unit tests validating that custom error messages work correctly
- Tests for various validation scenarios (valid/invalid patterns, required fields, string length)

## Example Usage

```csharp
[Required]
[StringLength(20, MinimumLength = 2)]
[RegularExpression(@"^[A-Z0-9-]+$", ErrorMessage = "The name field may only contain alpha-numeric characters as well as dashes.")]
public string ArtifactTypeCode { get; set; } = string.Empty;
```

## Build and Test

```bash
# Build the solution
dotnet build

# Run all tests
dotnet test
```

## Test Results

All 14 tests pass, confirming that custom error messages work correctly with the RegularExpression attribute.

See [DOCUMENTATION.md](DOCUMENTATION.md) for more details.