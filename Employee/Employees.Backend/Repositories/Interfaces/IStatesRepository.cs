using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Orders.Shared.Responses;

namespace Employees.Backend.Repositories.Interfaces;

public interface IStatesRepository
{
    Task<ActionResponse<State>> GetAsync(int id);
    Task<IEnumerable<State>> GetComboAsync(int countryId);
    Task<ActionResponse<IEnumerable<State>>> GetAsync();
    Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

}

