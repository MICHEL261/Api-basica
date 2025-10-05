using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Orders.Shared.Responses;

public interface IEmployeesUnitOfWork
{
    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination);
    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string text);
}