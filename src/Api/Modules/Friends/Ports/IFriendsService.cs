using Api.Modules.Friends.Core;

namespace Api.Modules.Friends.Ports;

public interface IFriendsService
{
    Task<FriendsResponse> GetMyFriends(CancellationToken cancellationToken);
}
