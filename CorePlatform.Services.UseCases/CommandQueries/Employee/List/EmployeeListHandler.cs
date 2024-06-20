using CorePlatform.Services.Core.Abstraction.Result;
using CorePlatform.Services.UseCases.Abstraction.Data;
using Dapper;
using MediatR;

namespace CorePlatform.Services.UseCases.CommandQueries.Employee.List
{
    public class EmployeeListHandler : IRequestHandler<EmployeeList, ResultInfo<List<EmployeeListResponseDTO>>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public EmployeeListHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ResultInfo<List<EmployeeListResponseDTO>>> Handle(EmployeeList request, CancellationToken cancellationToken)
        {
            using (var connection = _sqlConnectionFactory.CreateConnection())
            {
                var query = @"SELECT TOP 15
                                [FirstName],[LastName],[Gender],[DateOfBirth],[NetSalary],
                                [EmploymentStatus],[DateOfJoining] 
                            FROM 
                                [Employee]";
                var employee = await connection.QueryAsync<EmployeeListResponseDTO>(query);

                return ResultInfo<List<EmployeeListResponseDTO>>.Success(employee.ToList());
            }

        }
    }
}
