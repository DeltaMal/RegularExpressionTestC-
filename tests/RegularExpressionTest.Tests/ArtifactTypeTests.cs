using System.ComponentModel.DataAnnotations;
using Xunit;

namespace RegularExpressionTest.Tests;

public class ArtifactTypeTests
{
    [Fact]
    public void ValidArtifactTypeCode_ShouldPassValidation()
    {
        // Arrange
        var artifact = new ArtifactType
        {
            ArtifactTypeCode = "ABC123-XYZ"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(artifact);
        var isValid = Validator.TryValidateObject(artifact, validationContext, validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }

    [Fact]
    public void InvalidArtifactTypeCode_WithLowercase_ShouldFailWithCustomMessage()
    {
        // Arrange
        var artifact = new ArtifactType
        {
            ArtifactTypeCode = "abc123"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(artifact);
        var isValid = Validator.TryValidateObject(artifact, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Single(validationResults);
        Assert.Equal("The name field may only contain alpha-numeric characters as well as dashes and underscores.", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void InvalidArtifactTypeCode_WithSpecialCharacters_ShouldFailWithCustomMessage()
    {
        // Arrange
        var artifact = new ArtifactType
        {
            ArtifactTypeCode = "ABC@123"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(artifact);
        var isValid = Validator.TryValidateObject(artifact, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Single(validationResults);
        Assert.Equal("The name field may only contain alpha-numeric characters as well as dashes and underscores.", validationResults[0].ErrorMessage);
    }

    [Theory]
    [InlineData("ABC123")]
    [InlineData("XYZ-789")]
    [InlineData("TEST-CODE-1")]
    [InlineData("A1")]
    public void ValidArtifactTypeCodes_ShouldPassValidation(string code)
    {
        // Arrange
        var artifact = new ArtifactType
        {
            ArtifactTypeCode = code
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(artifact);
        var isValid = Validator.TryValidateObject(artifact, validationContext, validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("ABC_123")]
    [InlineData("ABC 123")]
    [InlineData("ABC!123")]
    public void InvalidArtifactTypeCodes_ShouldFailWithCustomMessage(string code)
    {
        // Arrange
        var artifact = new ArtifactType
        {
            ArtifactTypeCode = code
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(artifact);
        var isValid = Validator.TryValidateObject(artifact, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, vr => vr.ErrorMessage == "The name field may only contain alpha-numeric characters as well as dashes and underscores.");
    }

    [Fact]
    public void EmptyArtifactTypeCode_ShouldFailRequiredValidation()
    {
        // Arrange
        var artifact = new ArtifactType
        {
            ArtifactTypeCode = string.Empty
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(artifact);
        var isValid = Validator.TryValidateObject(artifact, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, vr => vr.ErrorMessage != null && vr.ErrorMessage.Contains("required"));
    }

    [Fact]
    public void TooShortArtifactTypeCode_ShouldFailStringLengthValidation()
    {
        // Arrange
        var artifact = new ArtifactType
        {
            ArtifactTypeCode = "A"
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(artifact);
        var isValid = Validator.TryValidateObject(artifact, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Single(validationResults);
    }

    [Fact]
    public void TooLongArtifactTypeCode_ShouldFailStringLengthValidation()
    {
        // Arrange
        var artifact = new ArtifactType
        {
            ArtifactTypeCode = "ABCDEFGHIJKLMNOPQRSTU"  // 21 characters
        };

        // Act
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(artifact);
        var isValid = Validator.TryValidateObject(artifact, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Single(validationResults);
    }
}
