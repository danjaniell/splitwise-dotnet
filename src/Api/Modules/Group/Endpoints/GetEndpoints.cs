using Api.Modules.Group.Core;
using Api.Modules.Group.Ports;
using Microsoft.AspNetCore.Http.HttpResults;
using Wolverine.Http;

namespace Api.Modules.Group.Endpoints;

public class GetEndpoints
{
    [WolverineGet("/getMyGroups")]
    public static async Task<Results<Ok<GroupsResponse>, NotFound>> GetMyGroups(
        HttpContext context,
        IGroupService groupService
    )
    {
        var cancellationToken = context.RequestAborted;
        return await groupService.GetMyGroups(cancellationToken) is GroupsResponse groups
            ? TypedResults.Ok(groups)
            : TypedResults.NotFound();
    }

    [WolverineGet("/getGroup/{id}")]
    public static async Task<Results<Ok<GroupResponse>, NotFound>> GetGroupById(
        int id,
        HttpContext context,
        IGroupService groupService
    )
    {
        var cancellationToken = context.RequestAborted;
        return await groupService.GetGroupById(id, cancellationToken) is GroupResponse group
            ? TypedResults.Ok(group)
            : TypedResults.NotFound();
    }
}
