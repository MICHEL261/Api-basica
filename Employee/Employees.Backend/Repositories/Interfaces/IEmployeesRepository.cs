using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Orders.Shared.Responses;

namespace Employees.Backend.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
        Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string text);
    }
}
