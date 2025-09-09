
using Employees.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace Employees.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckEmployeesAsync();
            
        }

        private async Task CheckEmployeesAsync()
        {
            if (!_context.Employees.Any())

                _context.Employees.AddRange(
                 new Employee { FirstName = "Luis", LastName = "Martinez", IsActive = true, HireDate = new DateTime(2023, 9, 8), Salary = 1_200_000 },
                 new Employee { FirstName = "Ana", LastName = "Gomez", IsActive = true, HireDate = new DateTime(2022, 5, 15), Salary = 1_500_000 },
                 new Employee { FirstName = "Carlos", LastName = "Lopez", IsActive = false, HireDate = new DateTime(2021, 12, 1), Salary = 1_100_000 },
                 new Employee { FirstName = "María", LastName = "Rodriguez", IsActive = true, HireDate = new DateTime(2020, 7, 23), Salary = 1_300_000 },
                 new Employee { FirstName = "Juan", LastName = "Pérez", IsActive = false, HireDate = new DateTime(2019, 3, 30), Salary = 1_400_000 },
                 new Employee { FirstName = "Sofía", LastName = "Fernandez", IsActive = true, HireDate = new DateTime(2018, 11, 11), Salary = 1_600_000 },
                 new Employee { FirstName = "Andrés", LastName = "Martinez", IsActive = true, HireDate = new DateTime(2017, 1, 5), Salary = 1_250_000 },
                 new Employee { FirstName = "Lucía", LastName = "Ramírez", IsActive = false, HireDate = new DateTime(2016, 9, 9), Salary = 1_350_000 },
                 new Employee { FirstName = "Juana", LastName = "Vargas", IsActive = true, HireDate = new DateTime(2015, 6, 20), Salary = 1_450_000 },
                 new Employee { FirstName = "Natalia", LastName = "Santos", IsActive = true, HireDate = new DateTime(2014, 4, 18), Salary = 1_550_000 }
             );
            await _context.SaveChangesAsync();  
        }
    }
}
