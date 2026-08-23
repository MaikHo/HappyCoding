using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HappyCoding.AvaloniaWithAsyncRelayCommand.Model;

namespace HappyCoding.AvaloniaWithAsyncRelayCommand.Services;

public interface IUserRepository
{
    Task<IReadOnlyList<UserInfo>> GetAllUsersAsync(CancellationToken cancellationToken);
}