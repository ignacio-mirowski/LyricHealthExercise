namespace LyricHealthExercise.Business.Models;

public class ClaimsSummary
{
    public int TotalClaimsCount { get; set; }
    public int ValidClaimsCount { get; set; }
    public int InvalidClaimsCount { get; set; }
    public decimal TotalApprovedAmount { get; set; }
}