# RegularExpression Custom Error Message Test

## Overview
This project demonstrates and tests the use of custom error messages with the `RegularExpression` attribute in C#.

## Project Structure

### Source Code
- **ArtifactType.cs**: A model class that demonstrates the use of the `RegularExpression` attribute with a custom error message.
  ```csharp
  [RegularExpression(@"^[A-Z0-9-]+$", ErrorMessage = "The name field may only contain alpha-numeric characters as well as dashes.")]
  ```

### Tests
- **ArtifactTypeTests.cs**: Comprehensive unit tests that validate:
  - Valid codes pass validation
  - Invalid codes trigger the custom error message
  - The custom error message is correctly displayed
  - All validation attributes work together (Required, StringLength, RegularExpression)

## Test Coverage
The test suite includes 14 test cases covering:
1. Valid codes with uppercase letters, numbers, and dashes
2. Invalid codes with lowercase letters
3. Invalid codes with special characters
4. Required field validation
5. String length validation (min 2, max 20 characters)
6. Multiple test cases using Theory and InlineData

## Running the Project

### Build
```bash
dotnet build
```

### Run Tests
```bash
dotnet test
```

### Test Results
All 14 tests pass successfully, confirming that:
- Custom error messages work correctly with the RegularExpression attribute
- The validation framework properly returns the custom error message when validation fails
- Multiple validation attributes can be combined effectively

## Key Learning Points
1. The `ErrorMessage` parameter in the `RegularExpression` attribute allows customization of validation error messages
2. Custom error messages are returned in `ValidationResult.ErrorMessage` when validation fails
3. The `Validator.TryValidateObject` method with `validateAllProperties: true` validates all attributes on a property
4. Data annotations work seamlessly together for comprehensive validation
