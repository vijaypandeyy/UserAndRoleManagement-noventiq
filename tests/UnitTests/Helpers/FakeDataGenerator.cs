using Bogus;
using Core;
using Core;
using System;
using System.Collections.Generic;

public static class FakeDataGenerator
{
    public static User GenerateFakeUser()
    {
        var faker = new Faker<User>()
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.Username, f => f.Internet.UserName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Password, f => "SecurePass123!") // Fake plain-text password
            .RuleFor(u => u.Roles, f => new HashSet<UserRole>());

        return faker.Generate();
    }

    public static List<User> GenerateFakeUsers(int count)
    {
        return new Faker<User>()
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.Username, f => f.Internet.UserName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Password, f => "SecurePass123!")
            .RuleFor(u => u.Roles, f => new HashSet<UserRole>())
            .Generate(count);
    }
}
