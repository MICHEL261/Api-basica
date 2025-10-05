using Employees.Backend.Repositories.Implementations;
using Employees.Backend.Repositories.Interfaces;
using Employees.Backend.UnitsOfWork.interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Orders.Backend.Repositories.Interfaces;
using Orders.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.Implementations
{
    public class EmployeesUnitOfWork : GenericUnitOfWork<Employee>, IEmployeesUnitOfWork
    {
        private readonly IEmployeesRepository _repository;

        public EmployeesUnitOfWork(IGenericRepository<Employee> repository, IEmployeesRepository employeesRepository) : base(repository)
        {
            _repository = employeesRepository;
        }

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _repository.GetTotalRecordsAsync(pagination);
        public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination) => await _repository.GetAsync(pagination);
        public async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string text)
        {
            return await _repository.GetAsync(text);
        }
    }
}
