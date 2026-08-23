using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.DataSets;
using HappyCoding.AvaloniaWithDependencyInjection.Model;

namespace HappyCoding.AvaloniaWithDependencyInjection.Services;

public class DesignDataUserService : IUserService
{
    public IReadOnlyList<UserInfo> GetAllUsers()
    {
        var testUserGenerator = new Faker<UserInfo>()
            .RuleFor(u => u.Gender, f => f.PickRandom<Name.Gender>().ToString())
            .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(Enum.Parse<Name.Gender>(u.Gender)))
            .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(Enum.Parse<Name.Gender>(u.Gender)))
            .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(u => u.EMail, (f, u) => f.Internet.Email(u.FirstName, u.LastName));

        return Enumerable
            .Range(0, 3)
            .Select(_ => testUserGenerator.Generate())
            .ToArray();
    }
}