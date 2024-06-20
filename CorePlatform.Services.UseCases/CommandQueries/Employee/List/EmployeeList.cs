using CorePlatform.Services.Core.Abstraction.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.UseCases.CommandQueries.Employee.List
{
    public record EmployeeList() : IRequest<ResultInfo<List<EmployeeResponseDTO>>>;
}
