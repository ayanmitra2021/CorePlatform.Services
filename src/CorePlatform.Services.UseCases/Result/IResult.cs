using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.UseCases.Result
{
    public enum ValidationSeverity
    {
        Error,
        Warning,
        Info
    }

    public enum ResultStatus
    {
        Ok,
        Error,
        Forbidden,
        Unauthorized,
        Invalid,
        NotFound,
        Conflict,
        CriticalError,
        Unavailable
    }

    public interface IResult
    {
        ResultStatus Status { get; }

        ObservableCollection<string> Errors { get; }

        ObservableCollection<ValidationError> ValidationErrors { get; }

        Type ValueType { get; }

        object GetValue();

    }
}
