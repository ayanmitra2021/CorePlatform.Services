using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.UseCases.Result
{
    public class Result : ResultInfo<Result>
    {
        public Result()
        {
        }

        protected internal Result(ResultStatus status)
            : base(status)
        {
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result SuccessWithMessage(string successMessage)
        {
            return new Result
            {
                SuccessMessage = successMessage
            };
        }

        public static ResultInfo<T> Success<T>(T value)
        {
            return new ResultInfo<T>(value);
        }

        public static ResultInfo<T> Success<T>(T value, string successMessage)
        {
            return new ResultInfo<T>(value, successMessage);
        }

        public new static Result Error(params string[] errorMessages)
        {
            Result result = new Result(ResultStatus.Error);
            if (errorMessages != null && errorMessages.Length != 0)
            {
                result.Errors = new ObservableCollection<string>(errorMessages);
            }

            result.Initialize();
            return result;
        }

        public static Result ErrorWithCorrelationId(string correlationId, params string[] errorMessages)
        {
            Result result = new Result(ResultStatus.Error);
            result.CorrelationId = correlationId;
            if (errorMessages != null && errorMessages.Length != 0)
            {
                result.Errors = new ObservableCollection<string>(errorMessages);
            }

            result.Initialize();
            return result;
        }

        public new static Result Invalid(ValidationError validationError)
        {
            return Invalid(new List<ValidationError> { validationError });
        }

        public new static Result Invalid(params ValidationError[] validationErrors)
        {
            Result result = new Result(ResultStatus.Invalid);
            if (validationErrors != null && validationErrors.Length != 0)
            {
                result.ValidationErrors = new ObservableCollection<ValidationError>(validationErrors);
            }

            result.Initialize();
            return result;
        }

        public new static Result Invalid(List<ValidationError> validationErrors)
        {
            return Invalid(validationErrors.ToArray());
        }

        public new static Result NotFound()
        {
            return NotFound((string[])null);
        }

        public new static Result NotFound(params string[] errorMessages)
        {
            Result result = new Result(ResultStatus.NotFound);
            if (errorMessages != null && errorMessages.Length != 0)
            {
                result.Errors = new ObservableCollection<string>(errorMessages);
            }

            result.Initialize();
            return result;
        }

        public new static Result Forbidden()
        {
            Result result = new Result(ResultStatus.Forbidden);
            result.Initialize();
            return result;
        }

        public new static Result Unauthorized()
        {
            Result result = new Result(ResultStatus.Unauthorized);
            result.Initialize();
            return result;
        }

        public new static Result Conflict()
        {
            return Conflict((string[])null);
        }

        public new static Result Conflict(params string[] errorMessages)
        {
            Result result = new Result(ResultStatus.Conflict);
            if (errorMessages != null && errorMessages.Length != 0)
            {
                result.Errors = new ObservableCollection<string>(errorMessages);
            }

            result.Initialize();
            return result;
        }

        public new static Result Unavailable(params string[] errorMessages)
        {
            Result result = new Result(ResultStatus.Unavailable);
            if (errorMessages != null && errorMessages.Length != 0)
            {
                result.Errors = new ObservableCollection<string>(errorMessages);
            }

            result.Initialize();
            return result;
        }

        public new static Result CriticalError(params string[] errorMessages)
        {
            Result result = new Result(ResultStatus.CriticalError);
            if (errorMessages != null && errorMessages.Length != 0)
            {
                result.Errors = new ObservableCollection<string>(errorMessages);
            }

            result.Initialize();
            return result;
        }
    }
}
