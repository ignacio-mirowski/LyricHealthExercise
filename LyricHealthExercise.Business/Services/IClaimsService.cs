using LyricHealthExercise.Business.Models;

namespace LyricHealthExercise.Business.Services;

public interface IClaimsService
{
    public ClaimsSummary CalculateClaimsSummary(IList<Claim> claims);
}