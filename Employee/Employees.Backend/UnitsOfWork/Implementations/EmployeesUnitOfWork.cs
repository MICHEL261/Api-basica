using Employees.Backend.UnitsOfWork.interfaces;
using Employees.Shared.Entities;
using Orders.Backend.Repositories.Interfaces;
using Orders.Shared.Responses;

namespace Employees.Backend.UnitsOfWork.Implementations
{
    public class EmployeesUnitOfWork : GenericUnitOfWork<Employee>, IEmployeesUnitOfWork
    {
        private readonly IGenericRepository<Employee> _repository;

        public EmployeesUnitOfWork(IGenericRepository<Employee> repository) : base(repository)
        {
            _repository = repository;
        }

        public virtual async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string text) => await _repository.GetAsync();

        
    }
}
