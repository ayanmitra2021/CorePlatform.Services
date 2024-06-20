using CorePlatform.Services.Core.Abstraction.Result;
using CorePlatform.Services.UseCases.Abstraction.Data;
using Dapper;
using MediatR;

namespace CorePlatform.Services.UseCases.CommandQueries.Employee.List
{
    public class EmployeeListHandler : IRequestHandler<EmployeeList, ResultInfo<List<EmployeeResponseDTO>>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public EmployeeListHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ResultInfo<List<EmployeeResponseDTO>>> Handle(EmployeeList request, CancellationToken cancellationToken)
        {
            using (var connection = _sqlConnectionFactory.CreateConnection())
            {
                var query = @"SELECT TOP 15
                                [Id],[FirstName],[LastName],[Gender],[DateOfBirth],[NetSalary],
                                [EmploymentStatus],[DateOfJoining], [TrainingCompleteDate],[RetirementDate],[ResignationDate] 
                            FROM 
                                [Employee]";
                var employee = await connection.QueryAsync<EmployeeResponseDTO>(query);

                return ResultInfo<List<EmployeeResponseDTO>>.Success(employee.ToList());
            }

        }
    }
}
