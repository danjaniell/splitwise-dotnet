using Api.Modules.Users.Core;
using Api.Modules.Users.Core.DTO;

namespace Api.Modules.Users.Ports;

public interface IUserService
{
    Task<UserResponse> GetCurrentUser(CancellationToken cancellationToken);
    Task<UserResponse> GetUserById(int id, CancellationToken cancellationToken);
    Task<bool> UpdateUser(int id, UserUpdate userUpdate, CancellationToken cancellationToken);
}
