using CorePlatform.Services.Core.Abstraction.Result;

namespace CorePlatform.Services.Core.Employee
{
    public static class EmployeeErrors
    {
        public static readonly ValidationError NotFound = new("Employee.NotFound", "The employee with the speficied id was not found", "ER01", ValidationSeverity.Error);

        public static readonly ValidationError InvalidJoinee = new("Employee.InvalidJoinee", "Only retired and resigned employees can join the firm", "ER02", ValidationSeverity.Error);

        public static readonly ValidationError InvalidTrainingCompletion = new("Employee.Training", "Only onboarded employees can be trained", "ER03", ValidationSeverity.Error);

        public static readonly ValidationError InvalidRetirement = new("Employee.Retirment", "Only onboarded or trained emploayees can retire", "ER04", ValidationSeverity.Error);

        public static readonly ValidationError InvalidResignation = new("Employee.Resignation", "Only onboarded or trained emploayees can resign", "ER05", ValidationSeverity.Error);

    }
}
