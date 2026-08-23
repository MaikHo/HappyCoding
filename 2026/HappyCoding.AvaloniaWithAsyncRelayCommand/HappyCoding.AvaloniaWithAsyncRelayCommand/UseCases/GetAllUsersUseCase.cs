using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HappyCoding.AvaloniaWithAsyncRelayCommand.Model;
using HappyCoding.AvaloniaWithAsyncRelayCommand.Services;

namespace HappyCoding.AvaloniaWithAsyncRelayCommand.UseCases;

public class GetAllUsersUseCase
{
    private readonly IUserRepository _userRepository;
    
    public GetAllUsersUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<IReadOnlyList<UserInfo>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllUsersAsync(cancellationToken)
            .ConfigureAwait(false);
    }
}