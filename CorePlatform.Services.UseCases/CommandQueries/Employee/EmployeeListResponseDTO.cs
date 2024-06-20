using CorePlatform.Services.Core.Employee.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.UseCases.CommandQueries.Employee
{
    public class EmployeeListResponseDTO
    {
        public EmployeeListResponseDTO() { }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public EmployeeGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public EmployeeStatus EmploymentStatus { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
