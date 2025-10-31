﻿using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Orders.Shared.Responses;

namespace Employees.Backend.Repositories.Interfaces;

public interface ICountriesRepository
{
    Task<ActionResponse<Country>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();
    Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination);
}
