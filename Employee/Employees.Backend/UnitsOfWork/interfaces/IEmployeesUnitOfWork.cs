using Employees.Shared.Entities;
using Orders.Shared.Responses;

public interface IEmployeesUnitOfWork
{
    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string text);
}