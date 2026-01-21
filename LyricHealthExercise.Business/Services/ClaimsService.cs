using LyricHealthExercise.Business.Models;

namespace LyricHealthExercise.Business.Services;

public class ClaimsService : IClaimsService
{
    public ClaimsSummary CalculateClaimsSummary(IList<Claim> claims)
    {
        var summary = new ClaimsSummary { TotalClaimsCount = claims.Count };
        
        foreach (var claim in claims)
        {
            if (claim.IsValid())
            {
                summary.ValidClaimsCount++; 
                summary.TotalApprovedAmount += claim.Status == Status.Approved ? claim.Amount : 0;
            }
            else
            {
                summary.InvalidClaimsCount++;
            }
        }

        return summary;
    }
}