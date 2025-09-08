using Employees.Backend.Data;
using Employees.Backend.Repositories.Interfaces;
using Employees.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Orders.Shared.Responses;


namespace Employees.Backend.Repositories.Implementations
{
    public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
    {

        private readonly DataContext _context;
        public EmployeesRepository(DataContext Context) : base(Context)
        {
            _context = Context; 
        }

        public async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string text)
        {
            text = text.ToLower();

            var result = await _context.Employees
                .Where(e => e.FirstName.ToLower().Contains(text) || e.LastName.ToLower().Contains(text))
                .ToListAsync();

            return new ActionResponse<IEnumerable<Employee>>
            {
                WasSuccess = true,
                Result = result
            };
        }

       
    }
}
