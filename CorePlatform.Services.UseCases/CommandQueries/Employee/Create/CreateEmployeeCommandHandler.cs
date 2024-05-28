using CorePlatform.Services.Core.Abstraction;
using CorePlatform.Services.Core.Abstraction.Result;
using CorePlatform.Services.Core.Employee;
using MediatR;

namespace CorePlatform.Services.UseCases.CommandQueries.Employee.Create
{

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ResultInfo<int>>
    {
        IEmployeeRepository _repository;
        IUnitOfWork _unitOfWork;

        public CreateEmployeeCommandHandler(IEmployeeRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultInfo<int>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Core.Employee.Employee(request.firstName, request.lastName, request.gender,
                                request.dateofBirth, request.netSalary, request.dateOfJoining);


            _repository.Add(employee);
            await _unitOfWork.SaveChangesAsync();

            return employee.Id;
        }
    }
}
