using CorePlatform.Services.Core.Employee.Enums;
using System.ComponentModel.DataAnnotations;

namespace CorePlatform.Services.Employee
{
    public class CreateEmployeeRequest
    {
        public const string Route = "/Employee";

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public EmployeeGender Gender { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public decimal NetSalary { get; set; } = 0;
        [Required]
        public EmployeeStatus EmploymentStatus { get; set; }
        [Required]
        public DateOnly DateOfJoining { get; set; }
        public DateOnly? TrainingCompleteDate { get; set; }
        public DateOnly? RetirementDate { get; set; }
        public DateOnly? ResignationDate { get; set; }
    }
}
