using Employees.Backend.Data;
using Employees.Backend.Helpers;
using Employees.Backend.Repositories.Interfaces;
using Employees.Shared.DTOs;
using Employees.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Orders.Shared.Responses;
using System.Diagnostics.Metrics;


namespace Employees.Backend.Repositories.Implementations
{
    public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
    {

        private readonly DataContext _context;
        public EmployeesRepository(DataContext Context) : base(Context)
        {
            _context = Context;
        }

        public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Employees

                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.FirstName.ToLower().Contains(pagination.Filter.ToLower()) || x.LastName.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<Employee>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(c => c.LastName)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }


        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.FirstName.ToLower().Contains(pagination.Filter.ToLower()) || x.LastName.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
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
