using LyricHealthExercise.Business.Models;
using LyricHealthExercise.Business.Services;

namespace LyricHealthExercise.Tests;

public class ClaimsServiceTests
{
    private IClaimsService _claimsService;
    
    [SetUp]
    public void Setup()
    {
        _claimsService = new ClaimsService();
    }

    [Test]
    public void CalculateClaimsSummary_WithValidClaims_ReturnsSummaryWithValidClaims()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new() { DiagnosisCode = "A12", Amount = 10m, Status = Status.Approved },
            new() { DiagnosisCode = "B23", Amount = 5m, Status = Status.Approved },
            new() { DiagnosisCode = "C34", Amount = 7m, Status = Status.Rejected }
        };

        // Act
        var summary = _claimsService.CalculateClaimsSummary(claims);

        // Assert
        Assert.That(summary.TotalClaimsCount, Is.EqualTo(3));
        Assert.That(summary.ValidClaimsCount, Is.EqualTo(3));
        Assert.That(summary.InvalidClaimsCount, Is.EqualTo(0));
        Assert.That(summary.TotalApprovedAmount, Is.EqualTo(15m));
    }
    
    [Test]
    public void ValidateClaims_WithInvalidClaims_ReturnSummaryWithInvalidClaims()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new() { DiagnosisCode = "", Amount = 10m, Status = Status.Approved },
            new() { DiagnosisCode = "1A", Amount = 5m, Status = Status.Approved },
            new() { DiagnosisCode = "A1", Amount = 0m, Status = Status.Approved }
        };

        // Act
        var summary = _claimsService.CalculateClaimsSummary(claims);

        // Assert
        Assert.That(summary.TotalClaimsCount, Is.EqualTo(3));
        Assert.That(summary.ValidClaimsCount, Is.EqualTo(0));
        Assert.That(summary.InvalidClaimsCount, Is.EqualTo(3));
        Assert.That(summary.TotalApprovedAmount, Is.EqualTo(0m));
    }
    
    [Test]
    public void ValidateClaims_WithMixOfValidAndInvalidClaims_ReturnsSummaryWithMixedValues()
    {
        // Arrange
        var claims = new List<Claim>
        {
            new() { DiagnosisCode = "A12", Amount = 20m, Status = Status.Approved },
            new() { DiagnosisCode = "B23", Amount = 30m, Status = Status.Rejected },
            new() { DiagnosisCode = "1C", Amount = 15m, Status = Status.Approved },
            new() { DiagnosisCode = "D4", Amount = 0m, Status = Status.Approved }
        };

        // Act
        var summary = _claimsService.CalculateClaimsSummary(claims);

        // Assert
        Assert.That(summary.TotalClaimsCount, Is.EqualTo(4));
        Assert.That(summary.ValidClaimsCount, Is.EqualTo(2));
        Assert.That(summary.InvalidClaimsCount, Is.EqualTo(2));
        Assert.That(summary.TotalApprovedAmount, Is.EqualTo(20m));
    }
}
