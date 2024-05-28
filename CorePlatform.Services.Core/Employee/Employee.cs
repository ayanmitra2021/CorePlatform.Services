using CorePlatform.Services.Core.Abstraction;
using CorePlatform.Services.Core.Abstraction.Result;
using CorePlatform.Services.Core.Employee.Enums;
using CorePlatform.Services.Core.Employee.Events;

namespace CorePlatform.Services.Core.Employee
{
    public sealed class Employee : EntityBase
    {
        private Employee() { }

        public Employee(string firstName, string lastName, EmployeeGender gender, DateOnly dateOfBirth, decimal netSalary, DateOnly dateOfJoining)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            NetSalary = netSalary;
            DateOfJoining = dateOfJoining;
            EmploymentStatus = EmployeeStatus.Onboarded;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public EmployeeGender Gender { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public decimal NetSalary { get; private set; } = 0;
        public EmployeeStatus EmploymentStatus { get; private set; }
        public DateOnly DateOfJoining { get; private set; }
        public DateOnly? TrainingCompleteDate { get; private set; }
        public DateOnly? RetirementDate { get; private set; }
        public DateOnly? ResignationDate { get; private set; }

        public Result Joined(DateOnly dateOfJoining)
        {
            if (!(EmploymentStatus == EmployeeStatus.Resigned || EmploymentStatus == EmployeeStatus.Retired))
            {
                return Result.Invalid(EmployeeErrors.InvalidJoinee);
            }

            DateOfJoining = dateOfJoining;
            EmploymentStatus = EmployeeStatus.Onboarded;
            RaiseDomainEvent(new EmployeeJoiningEvent(Id));

            return Result.Success();
        }

        public Result TrainingComplete(DateOnly trainingCompleteDate)
        {
            if (EmploymentStatus != EmployeeStatus.Onboarded)
            {
                return Result.Invalid(EmployeeErrors.InvalidTrainingCompletion);
            }

            TrainingCompleteDate = trainingCompleteDate;
            EmploymentStatus = EmployeeStatus.Trained;
            RaiseDomainEvent(new EmployeeTrainingCompleteEvent(Id));

            return Result.Success();
        }

        public Result Retired(DateOnly retirementDate)
        {
            if (!(EmploymentStatus == EmployeeStatus.Onboarded || EmploymentStatus == EmployeeStatus.Trained))
            {
                return Result.Invalid(EmployeeErrors.InvalidRetirement);
            }

            RetirementDate = retirementDate;
            EmploymentStatus = EmployeeStatus.Retired;
            RaiseDomainEvent(new EmployeeRetirementEvent(Id));

            return Result.Success();
        }

        public Result Resigned(DateOnly resignationDate)
        {
            if (!(EmploymentStatus == EmployeeStatus.Onboarded || EmploymentStatus == EmployeeStatus.Trained))
            {
                return Result.Invalid(EmployeeErrors.InvalidResignation);
            }

            ResignationDate = resignationDate;
            EmploymentStatus = EmployeeStatus.Retired;
            RaiseDomainEvent(new EmployeeResignationEvent(Id));

            return Result.Success();
        }
    }
}
