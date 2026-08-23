using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using HappyCoding.AvaloniaWithAsyncRelayCommand.Model;

namespace HappyCoding.AvaloniaWithAsyncRelayCommand.Services;

public class RandomGeneratedUserRepository : IUserRepository
{
    private const int WAIT_TIME_MS = 2000;
    private const int GENERATED_USER_COUNT = 100;
    
    public async Task<IReadOnlyList<UserInfo>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(WAIT_TIME_MS, cancellationToken)
            .ConfigureAwait(false);
        
        var testUserGenerator = new Faker<UserInfo>()
            .RuleFor(u => u.Gender, f => f.PickRandom<Name.Gender>().ToString())
            .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(Enum.Parse<Name.Gender>(u.Gender)))
            .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(Enum.Parse<Name.Gender>(u.Gender)))
            .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(u => u.EMail, (f, u) => f.Internet.Email(u.FirstName, u.LastName));

        return Enumerable
            .Range(0, GENERATED_USER_COUNT)
            .Select(_ => testUserGenerator.Generate())
            .ToArray();
    }
}