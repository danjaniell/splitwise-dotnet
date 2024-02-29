using Api.Modules.Users.Core;
using Api.Modules.Users.Ports;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Modules.Users.Endpoints;

public static class GetEndpoint
{
    public static Func<
        HttpContext,
        IUserService,
        Task<Results<Ok<UserResponse>, NotFound>>
    > GetCurrentUser()
    {
        return async Task<Results<Ok<UserResponse>, NotFound>> (
            HttpContext context,
            IUserService userService
        ) =>
        {
            var cancellationToken = context.RequestAborted;
            return await userService.GetCurrentUser(cancellationToken) is UserResponse user
                ? TypedResults.Ok(user)
                : TypedResults.NotFound();
        };
    }
}
