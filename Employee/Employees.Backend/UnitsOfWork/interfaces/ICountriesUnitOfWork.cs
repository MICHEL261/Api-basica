using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Orders.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.interfaces;
public interface ICountriesUnitOfWork
{
    Task<ActionResponse<Country>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();
    Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination);
    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    Task<IEnumerable<Country>> GetComboAsync();
}
