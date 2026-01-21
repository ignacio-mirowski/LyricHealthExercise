using LyricHealthExercise.Business.Models;

namespace LyricHealthExercise.Tests;

public class ClaimTest
{
    [Test]
    public void IsValidCode_WithEmptyCode_ReturnsFalse()
    {
        // Arrange
        var claim = new Claim { DiagnosisCode = string.Empty };

        // Act
        var result = claim.IsValidCode();

        // Assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    [TestCase("1A")]
    [TestCase("12")]
    public void IsValidCode_WithoutLetterAsFirstDigit_ReturnsFalse(string code)
    {
        // Arrange
        var claim = new Claim { DiagnosisCode = code };

        // Act
        var result = claim.IsValidCode();

        // Assert
        Assert.That(result, Is.False);
    }
    
    [TestCase("A")]
    [TestCase("A12345")]
    public void IsValidCode_Without2to5Characters_ReturnsFalse(string code)
    {
        // Arrange
        var claim = new Claim { DiagnosisCode = code };

        // Act
        var result = claim.IsValidCode();

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase("A1B")]
    [TestCase("A12B")]
    public void IsValidCode_WithLettersAfterFirst_ReturnsFalse(string code)
    {
        // Arrange
        var claim = new Claim { DiagnosisCode = code };

        // Act
        var result = claim.IsValidCode();

        // Assert
        Assert.That(result, Is.False);
    }

        
    [Test]
    public void IsValidCode_WithValidValue_ReturnsTrue()
    {
        // Arrange
        var claim = new Claim { DiagnosisCode = "A12" };

        // Act
        var result = claim.IsValidCode();

        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void IsValidAmount_WithValueLessOrEqualToZero_ReturnsFalse()
    {
        // Arrange
        var claim = new Claim { Amount = 0m };

        // Act
        var result = claim.IsValidAmount();

        // Assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void IsValidAmount_WithValueBiggerThan0_ReturnsTrue()
    {
        // Arrange
        var claim = new Claim { Amount = 0.01m };

        // Act
        var result = claim.IsValidAmount();

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsValid_WithValidCodeAndAmount_ReturnsTrue()
    {
        // Arrange
        var claim = new Claim { DiagnosisCode = "B23", Amount = 10m };

        // Act
        var result = claim.IsValid();

        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void IsValid_WithInvalidCode_ReturnsFalse()
    {
        // Arrange
        var claim = new Claim { DiagnosisCode = "1B", Amount = 10m };

        // Act
        var result = claim.IsValid();

        // Assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void IsValid_WithInvalidAmount_ReturnsFalse()
    {
        // Arrange
        var claim = new Claim { DiagnosisCode = "C1", Amount = 0m };

        // Act
        var result = claim.IsValid();

        // Assert
        Assert.That(result, Is.False);
    }
}
