using CorePlatform.Services.Core.Abstraction.Result;

namespace CorePlatform.Services.UseCases.Exceptions
{

    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationError> Errors { get; set; }
    }
}