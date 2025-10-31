
using Employees.Backend.UnitsOfWork.interfaces;
using Employees.Shared.Entities;
using Employees.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Employees.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUsersUnitOfWork _usersUnitOfWork;


        public SeedDb(DataContext context, IUsersUnitOfWork usersUnitOfWork)
        {
            _context = context;
            _usersUnitOfWork = usersUnitOfWork;

        }


        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckEmployeesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Juan", "Zuluaga", "zulu@yopmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.Admin);
            await CheckCountriesFullAsync();


        }
        private async Task CheckCountriesFullAsync()
        {
            if (!_context.Countries.Any())
            {
                var countriesSQLScript = File.ReadAllText("Data\\CountriesStatesCities.sql");
                await _context.Database.ExecuteSqlRawAsync(countriesSQLScript);
            }
        }


        private async Task CheckRolesAsync()
        {
            await _usersUnitOfWork.CheckRoleAsync(UserType.Admin.ToString());
            await _usersUnitOfWork.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _usersUnitOfWork.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                   
                    UserType = userType,
                };

                await _usersUnitOfWork.AddUserAsync(user, "123456");
                await _usersUnitOfWork.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckEmployeesAsync()
        {
            if (!_context.Employees.Any())

                _context.Employees.AddRange(
                 new Employee { FirstName = "Luis", LastName = "Martinez", IsActive = true, HireDate = new DateTime(2023, 9, 8), Salary = 1_200_000 },
            new Employee { FirstName = "Ana", LastName = "Gomez", IsActive = true, HireDate = new DateTime(2022, 5, 15), Salary = 1_500_000 },
            new Employee { FirstName = "Carlos", LastName = "Lopez", IsActive = false, HireDate = new DateTime(2021, 12, 1), Salary = 1_100_000 },
            new Employee { FirstName = "Maria", LastName = "Rodriguez", IsActive = true, HireDate = new DateTime(2020, 7, 23), Salary = 1_300_000 },
            new Employee { FirstName = "Juan", LastName = "Perez", IsActive = false, HireDate = new DateTime(2019, 3, 30), Salary = 1_400_000 },
            new Employee { FirstName = "Sofia", LastName = "Fernandez", IsActive = true, HireDate = new DateTime(2018, 11, 11), Salary = 1_600_000 },
            new Employee { FirstName = "Andres", LastName = "Martinez", IsActive = true, HireDate = new DateTime(2017, 1, 5), Salary = 1_250_000 },
            new Employee { FirstName = "Lucia", LastName = "Ramirez", IsActive = false, HireDate = new DateTime(2016, 9, 9), Salary = 1_350_000 },
            new Employee { FirstName = "Juana", LastName = "Vargas", IsActive = true, HireDate = new DateTime(2015, 6, 20), Salary = 1_450_000 },
            new Employee { FirstName = "Natalia", LastName = "Santos", IsActive = true, HireDate = new DateTime(2014, 4, 18), Salary = 1_550_000 },

            new Employee { FirstName = "Pedro", LastName = "Castillo", IsActive = true, HireDate = new DateTime(2023, 2, 12), Salary = 1_200_000 },
            new Employee { FirstName = "Camila", LastName = "Mendoza", IsActive = false, HireDate = new DateTime(2022, 6, 10), Salary = 1_300_000 },
            new Employee { FirstName = "Mateo", LastName = "Herrera", IsActive = true, HireDate = new DateTime(2021, 1, 25), Salary = 1_350_000 },
            new Employee { FirstName = "Valentina", LastName = "Silva", IsActive = true, HireDate = new DateTime(2020, 9, 14), Salary = 1_400_000 },
            new Employee { FirstName = "Sebastian", LastName = "Morales", IsActive = false, HireDate = new DateTime(2019, 11, 3), Salary = 1_100_000 },
            new Employee { FirstName = "Isabella", LastName = "Romero", IsActive = true, HireDate = new DateTime(2018, 8, 22), Salary = 1_600_000 },
            new Employee { FirstName = "Diego", LastName = "Ortega", IsActive = true, HireDate = new DateTime(2017, 4, 5), Salary = 1_250_000 },
            new Employee { FirstName = "Renata", LastName = "Delgado", IsActive = false, HireDate = new DateTime(2016, 2, 27), Salary = 1_300_000 },
            new Employee { FirstName = "Gabriel", LastName = "Rios", IsActive = true, HireDate = new DateTime(2015, 12, 15), Salary = 1_450_000 },
            new Employee { FirstName = "Florencia", LastName = "Acosta", IsActive = true, HireDate = new DateTime(2014, 7, 8), Salary = 1_550_000 },

            new Employee { FirstName = "Tomas", LastName = "Luna", IsActive = true, HireDate = new DateTime(2023, 5, 4), Salary = 1_220_000 },
            new Employee { FirstName = "Martina", LastName = "Ibarra", IsActive = false, HireDate = new DateTime(2022, 10, 1), Salary = 1_310_000 },
            new Employee { FirstName = "Emiliano", LastName = "Peña", IsActive = true, HireDate = new DateTime(2021, 3, 19), Salary = 1_360_000 },
            new Employee { FirstName = "Josefina", LastName = "Rojas", IsActive = true, HireDate = new DateTime(2020, 6, 11), Salary = 1_410_000 },
            new Employee { FirstName = "Agustin", LastName = "Cabrera", IsActive = false, HireDate = new DateTime(2019, 8, 30), Salary = 1_120_000 },
            new Employee { FirstName = "Antonia", LastName = "Leiva", IsActive = true, HireDate = new DateTime(2018, 3, 13), Salary = 1_610_000 },
            new Employee { FirstName = "Facundo", LastName = "Reyes", IsActive = true, HireDate = new DateTime(2017, 5, 20), Salary = 1_260_000 },
            new Employee { FirstName = "Paula", LastName = "Maldonado", IsActive = false, HireDate = new DateTime(2016, 1, 17), Salary = 1_310_000 },
            new Employee { FirstName = "Maximiliano", LastName = "Vega", IsActive = true, HireDate = new DateTime(2015, 11, 5), Salary = 1_470_000 },
            new Employee { FirstName = "Constanza", LastName = "Fuentes", IsActive = true, HireDate = new DateTime(2014, 2, 25), Salary = 1_570_000 },

            new Employee { FirstName = "Bruno", LastName = "Salazar", IsActive = true, HireDate = new DateTime(2023, 7, 21), Salary = 1_210_000 },
            new Employee { FirstName = "Emily", LastName = "Navarro", IsActive = false, HireDate = new DateTime(2022, 11, 9), Salary = 1_320_000 },
            new Employee { FirstName = "Benjamin", LastName = "Soto", IsActive = true, HireDate = new DateTime(2021, 2, 3), Salary = 1_370_000 },
            new Employee { FirstName = "Julia", LastName = "Pizarro", IsActive = true, HireDate = new DateTime(2020, 10, 19), Salary = 1_420_000 },
            new Employee { FirstName = "Ivan", LastName = "Espinoza", IsActive = false, HireDate = new DateTime(2019, 5, 27), Salary = 1_130_000 },
            new Employee { FirstName = "Carla", LastName = "Gallardo", IsActive = true, HireDate = new DateTime(2018, 6, 2), Salary = 1_620_000 },
            new Employee { FirstName = "Simon", LastName = "Tapia", IsActive = true, HireDate = new DateTime(2017, 9, 16), Salary = 1_270_000 },
            new Employee { FirstName = "Laura", LastName = "Muñoz", IsActive = false, HireDate = new DateTime(2016, 12, 8), Salary = 1_320_000 },
            new Employee { FirstName = "Felipe", LastName = "Cortez", IsActive = true, HireDate = new DateTime(2015, 4, 4), Salary = 1_480_000 },
            new Employee { FirstName = "Daniela", LastName = "Carrasco", IsActive = true, HireDate = new DateTime(2014, 1, 12), Salary = 1_580_000 },

            new Employee { FirstName = "Alonso", LastName = "Garrido", IsActive = true, HireDate = new DateTime(2023, 8, 15), Salary = 1_230_000 },
            new Employee { FirstName = "Monica", LastName = "Arce", IsActive = false, HireDate = new DateTime(2022, 3, 12), Salary = 1_340_000 },
            new Employee { FirstName = "Ricardo", LastName = "Palacios", IsActive = true, HireDate = new DateTime(2021, 9, 30), Salary = 1_390_000 },
            new Employee { FirstName = "Patricia", LastName = "Lagos", IsActive = true, HireDate = new DateTime(2020, 12, 5), Salary = 1_410_000 },
            new Employee { FirstName = "Eduardo", LastName = "Mejia", IsActive = false, HireDate = new DateTime(2019, 1, 18), Salary = 1_140_000 },
            new Employee { FirstName = "Adriana", LastName = "Castañeda", IsActive = true, HireDate = new DateTime(2018, 10, 22), Salary = 1_630_000 },
            new Employee { FirstName = "oscar", LastName = "Zamora", IsActive = true, HireDate = new DateTime(2017, 7, 1), Salary = 1_280_000 },
            new Employee { FirstName = "Veronica", LastName = "Camacho", IsActive = false, HireDate = new DateTime(2016, 5, 14), Salary = 1_330_000 },
            new Employee { FirstName = "Manuel", LastName = "Quiroz", IsActive = true, HireDate = new DateTime(2015, 2, 9), Salary = 1_490_000 },
            new Employee { FirstName = "Fernanda", LastName = "Villalobos", IsActive = true, HireDate = new DateTime(2014, 6, 30), Salary = 1_590_000 }
             );
            await _context.SaveChangesAsync();  
        }
    }
}
