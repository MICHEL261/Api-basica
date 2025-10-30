﻿using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace Employees.Backend.Repositories.Interfaces;

public interface IUsersRepository
{

    Task<User> GetUserAsync(string email);
    Task<SignInResult> LoginAsync(LoginDTO model);

    Task LogoutAsync();

    Task<IdentityResult> AddUserAsync(User user, string password);

    Task CheckRoleAsync(string roleName);

    Task AddUserToRoleAsync(User user, string roleName);

    Task<bool> IsUserInRoleAsync(User user, string roleName);
}
