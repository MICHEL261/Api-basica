﻿using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Orders.Shared.Responses;

namespace Employees.Backend.Repositories.Interfaces;

public interface ICitiesRepository
{
    Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
}

