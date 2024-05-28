namespace CorePlatform.Services.Employee
{
    public class GetEmployeeByIdRequest
    {
        public const string Route = "/Employee/{employeeId:int}";

        public int EmployeeId { get; set; }
    }
}
