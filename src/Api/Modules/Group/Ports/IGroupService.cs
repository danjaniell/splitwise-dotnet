using Api.Modules.Group.Core;

namespace Api.Modules.Group.Ports;

public interface IGroupService
{
    Task<GroupsResponse> GetMyGroups(CancellationToken cancellationToken);

    Task<GroupResponse> GetGroupById(int id, CancellationToken cancellationToken);
}
