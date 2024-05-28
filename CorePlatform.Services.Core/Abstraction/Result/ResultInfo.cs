using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace CorePlatform.Services.Core.Abstraction.Result
{
    public class ResultInfo<T> : IResult
    {
        private ObservableCollection<string> _errors = new ObservableCollection<string>();

        private ObservableCollection<ValidationError> _validationErrors = new ObservableCollection<ValidationError>();

        [JsonInclude]
        public T Value { get; init; }

        [JsonIgnore]
        public Type ValueType => typeof(T);

        private ResultStatus InitialStatus { get; set; }

        [JsonInclude]
        public ResultStatus Status { get; protected set; }

        public bool IsSuccess => Status == ResultStatus.Ok;

        [JsonInclude]
        public string SuccessMessage { get; protected set; } = string.Empty;


        [JsonInclude]
        public string CorrelationId { get; protected set; } = string.Empty;


        [JsonInclude]
        public ObservableCollection<string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
                Errors_CollectionChanged(_errors, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        [JsonInclude]
        public ObservableCollection<ValidationError> ValidationErrors
        {
            get
            {
                return _validationErrors;
            }
            set
            {
                _validationErrors = value;
                ValidationErrors_CollectionChanged(_validationErrors, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        protected ResultInfo()
        {
            Initialize();
        }

        public ResultInfo(T value)
        {
            Value = value;
            Initialize();
        }

        protected internal ResultInfo(T value, string successMessage)
            : this(value)
        {
            SuccessMessage = successMessage;
            Initialize();
        }

        protected ResultInfo(ResultStatus status)
        {
            Status = status;
            Initialize();
        }

        protected void Initialize()
        {
            InitialStatus = Status;
            ValidationErrors.CollectionChanged += ValidationErrors_CollectionChanged;
            Errors.CollectionChanged += Errors_CollectionChanged;
        }

        protected void ValidationErrors_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            EvaluateResultStatus();
        }

        protected void Errors_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            EvaluateResultStatus();
        }

        private void EvaluateResultStatus()
        {
            if (ShouldParseStatusBasedOnResultStatus())
            {
                if (Errors.Count > 0)
                {
                    Status = ResultStatus.Error;
                }
                else if (ValidationErrors.Count > 0)
                {
                    Status = ResultStatus.Invalid;
                }
                else
                {
                    Status = InitialStatus;
                }
            }
        }

        private bool ShouldParseStatusBasedOnResultStatus()
        {
            if (Status != 0 && Status != ResultStatus.Error)
            {
                return Status == ResultStatus.Invalid;
            }

            return true;
        }

        public static implicit operator T(ResultInfo<T> result)
        {
            return result.Value;
        }

        public static implicit operator ResultInfo<T>(T value)
        {
            return new ResultInfo<T>(value);
        }

        public static implicit operator ResultInfo<T>(Result result)
        {
            return new ResultInfo<T>(default(T))
            {
                Status = result.Status,
                InitialStatus = result.InitialStatus,
                Errors = result.Errors,
                SuccessMessage = result.SuccessMessage,
                CorrelationId = result.CorrelationId,
                ValidationErrors = result.ValidationErrors
            };
        }

        public object GetValue()
        {
            return Value;
        }

        public PagedResult<T> ToPagedResult(PagedInfo pagedInfo)
        {
            return new PagedResult<T>(pagedInfo, Value)
            {
                Status = Status,
                InitialStatus = InitialStatus,
                SuccessMessage = SuccessMessage,
                CorrelationId = CorrelationId,
                Errors = Errors,
                ValidationErrors = ValidationErrors
            };
        }

        public static ResultInfo<T> Success(T value)
        {
            return new ResultInfo<T>(value);
        }

        public static ResultInfo<T> Success(T value, string successMessage)
        {
            return new ResultInfo<T>(value, successMessage);
        }

        public static ResultInfo<T> Error(params string[] errorMessages)
        {
            ResultInfo<T> result = new ResultInfo<T>(ResultStatus.Error);
            if (errorMessages != null && errorMessages.Length != 0)
            {
                result.Errors = new ObservableCollection<string>(errorMessages);
            }

            return result;
        }

        public static ResultInfo<T> Invalid(ValidationError validationError)
        {
            return new ResultInfo<T>(ResultStatus.Invalid)
            {
                ValidationErrors = { validationError }
            };
        }

        public static ResultInfo<T> Invalid(params ValidationError[] validationErrors)
        {
            ResultInfo<T> result = new ResultInfo<T>(ResultStatus.Invalid);
            if (validationErrors != null && validationErrors.Length != 0)
            {
                result.ValidationErrors = new ObservableCollection<ValidationError>(validationErrors);
            }

            return result;
        }

        public static ResultInfo<T> Invalid(List<ValidationError> validationErrors)
        {
            return Invalid(validationErrors.ToArray());
        }

        public static ResultInfo<T> NotFound()
        {
            return new ResultInfo<T>(ResultStatus.NotFound);
        }

        public static ResultInfo<T> NotFound(params string[] errorMessages)
        {
            ResultInfo<T> result = new ResultInfo<T>(ResultStatus.NotFound);
            if (errorMessages != null || errorMessages.Length != 0)
            {
                result.Errors = new ObservableCollection<string>(errorMessages);
            }

            return result;
        }

        public static ResultInfo<T> Forbidden()
        {
            return new ResultInfo<T>(ResultStatus.Forbidden);
        }

        public static ResultInfo<T> Unauthorized()
        {
            return new ResultInfo<T>(ResultStatus.Unauthorized);
        }

        public static ResultInfo<T> Conflict()
        {
            return new ResultInfo<T>(ResultStatus.Conflict);
        }

        public static ResultInfo<T> Conflict(params string[] errorMessages)
        {
            ResultInfo<T> result = new ResultInfo<T>(ResultStatus.Conflict);
            if (errorMessages != null || errorMessages.Length != 0)
            {
                result.Errors = new ObservableCollection<string>(errorMessages);
            }

            return result;
        }

        public static ResultInfo<T> CriticalError(params string[] errorMessages)
        {
            ResultInfo<T> result = new ResultInfo<T>(ResultStatus.CriticalError);
            if (errorMessages != null || errorMessages.Length != 0)
            {
                result.Errors = new ObservableCollection<string>(errorMessages);
            }

            return result;
        }

        public static ResultInfo<T> Unavailable(params string[] errorMessages)
        {
            ResultInfo<T> result = new ResultInfo<T>(ResultStatus.Unavailable);
            if (errorMessages != null || errorMessages.Length != 0)
            {
                result.Errors = new ObservableCollection<string>(errorMessages);
            }

            return result;
        }
    }
}