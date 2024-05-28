using CorePlatform.Services.Core.Abstraction;
using CorePlatform.Services.Core.Abstraction.Result;
using CorePlatform.Services.Core.Employee;
using MediatR;

namespace CorePlatform.Services.UseCases.CommandQueries.Employee.Query
{
    public class EmployeeQueryHandler : IRequestHandler<EmployeeQuery, ResultInfo<EmployeeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeQueryHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
        }

        public async Task<ResultInfo<EmployeeResponseDTO>> Handle(EmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.employeeId);
            if (employee == null)
            {
                return Result.Error("Employee not found");
            }

            return new EmployeeResponseDTO(employee.Id, employee.FirstName, employee.LastName,
                employee.Gender, employee.DateOfBirth, employee.NetSalary, employee.EmploymentStatus,
                employee.DateOfJoining, employee.TrainingCompleteDate, employee.ResignationDate, employee.RetirementDate);
        }
    }
}
