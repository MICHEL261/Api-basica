using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Orders.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.interfaces;

public interface IStatesUnitOfWork
{
    Task<ActionResponse<State>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<State>>> GetAsync();
    Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination);
    Task<IEnumerable<State>> GetComboAsync(int countryId);
    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

}

