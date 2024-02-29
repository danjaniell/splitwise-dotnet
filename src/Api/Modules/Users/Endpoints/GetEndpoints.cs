using Api.Modules.Users.Core;
using Api.Modules.Users.Ports;
using Microsoft.AspNetCore.Http.HttpResults;
using Wolverine.Http;

namespace Api.Modules.Users.Endpoints;

public static class GetEndpoints
{
    [WolverineGet("/getCurrentUser")]
    public static async Task<Results<Ok<UserResponse>, NotFound>> GetCurrentUser(
        HttpContext context,
        IUserService userService
    )
    {
        var cancellationToken = context.RequestAborted;
        return await userService.GetCurrentUser(cancellationToken) is UserResponse user
            ? TypedResults.Ok(user)
            : TypedResults.NotFound();
    }
}
