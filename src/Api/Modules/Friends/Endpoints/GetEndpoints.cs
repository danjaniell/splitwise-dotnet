using Api.Modules.Friends.Core;
using Api.Modules.Friends.Ports;
using Microsoft.AspNetCore.Http.HttpResults;
using Wolverine.Http;

namespace Api.Modules.Friends.Endpoints;

public class GetEndpoints
{
    [WolverineGet("/getMyFriends")]
    public static async Task<Results<Ok<FriendsResponse>, NotFound>> GetMyFriends(
        HttpContext context,
        IFriendsService friendsService
    )
    {
        var cancellationToken = context.RequestAborted;
        return await friendsService.GetMyFriends(cancellationToken) is FriendsResponse groups
            ? TypedResults.Ok(groups)
            : TypedResults.NotFound();
    }
}
