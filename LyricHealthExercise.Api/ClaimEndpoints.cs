using LyricHealthExercise.Business.Models;
using LyricHealthExercise.Business.Services;

namespace LyricHealthExercise.Api;

public static class ClaimEndpoints
{
    public static IEndpointRouteBuilder MapClaimEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/claims/validate", ClaimsValidate);

        return endpoints;
    }

    static IResult ClaimsValidate(IClaimsService claimsService, IList<Claim> claims)
    {
        var result = claimsService.CalculateClaimsSummary(claims);
        return Results.Ok(result);
    }
}