using Api.Modules.Users.Core;

namespace Api.Modules.Users.Ports;

public interface IUserService
{
    Task<UserResponse> GetCurrentUser(CancellationToken cancellationToken);
}
