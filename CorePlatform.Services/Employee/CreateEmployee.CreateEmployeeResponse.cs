using CorePlatform.Services.Core.Employee.Enums;

namespace CorePlatform.Services.Employee
{
    public class CreateEmployeeResponse
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required EmployeeGender Gender { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required decimal NetSalary { get; set; } = 0;
        public required EmployeeStatus EmploymentStatus { get; set; }
        public required DateOnly DateOfJoining { get; set; }
        public DateOnly? TrainingCompleteDate { get; set; }
        public DateOnly? RetirementDate { get; set; }
        public DateOnly? ResignationDate { get; set; }
    }
}
