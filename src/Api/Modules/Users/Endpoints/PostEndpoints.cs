using Api.Modules.Users.Core;
using Api.Modules.Users.Core.DTO;
using Api.Modules.Users.Ports;
using Microsoft.AspNetCore.Http.HttpResults;
using Wolverine.Http;

namespace Api.Modules.Users.Endpoints;

public class PostEndpoints
{
    [WolverinePost("/updateUser/{id}")]
    public static async Task<Results<Ok, NotFound>> GetCurrentUser(
        int id,
        UserUpdate userUpdate,
        HttpContext context,
        IUserService userService
    )
    {
        var cancellationToken = context.RequestAborted;
        return await userService.UpdateUser(id, userUpdate, cancellationToken)
            ? TypedResults.Ok()
            : TypedResults.NotFound();
    }
}
