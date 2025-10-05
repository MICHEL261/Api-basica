using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Orders.Shared.Responses;

namespace Employees.Backend.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string text);
        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}
