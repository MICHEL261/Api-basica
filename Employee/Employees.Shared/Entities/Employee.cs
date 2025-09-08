using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Shared.Entities
{
    public class Employee
    {

        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string FirstName { get; set; } = null!;
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string LastName { get; set; }=null!;
        public bool IsActive { get; set; }
        public DateTime HireDate { get; set; }
        [Range(typeof(decimal), "1000000", "100000000", ErrorMessage = "El salario debe ser al menos de {1}.")]
        public Decimal Salary { get; set; }

    }
}
