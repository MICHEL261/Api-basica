using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Orders.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.interfaces;

public interface ICitiesUnitOfWork
{
    Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);
    Task<IEnumerable<City>> GetComboAsync(int stateId);
    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
}

