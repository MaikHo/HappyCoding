using System.Collections.Generic;
using HappyCoding.AvaloniaWithDependencyInjection.Model;

namespace HappyCoding.AvaloniaWithDependencyInjection.Services;

public interface IUserService
{
    IReadOnlyList<UserInfo> GetAllUsers();
}