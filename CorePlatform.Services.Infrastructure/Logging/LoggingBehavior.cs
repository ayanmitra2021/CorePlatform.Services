using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Ardalis.GuardClauses;

namespace CorePlatform.Services.Infrastructure.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<Mediator> _logger;

        public LoggingBehavior(ILogger<Mediator> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Guard.Against.Null(request, "request");
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Handling {RequestName}", typeof(TRequest).Name);
                foreach (PropertyInfo item in (IEnumerable<PropertyInfo>)new List<PropertyInfo>(request.GetType().GetProperties()))
                {
                    object obj = item?.GetValue(request, null);
                    _logger.LogInformation("Property {Property} : {@Value}", item?.Name, obj);
                }
            }

            Stopwatch sw = Stopwatch.StartNew();
            TResponse val = await next();
            _logger.LogInformation("Handled {RequestName} with {Response} in {ms} ms", typeof(TRequest).Name, val, sw.ElapsedMilliseconds);
            sw.Stop();
            return val;
        }
    }
}
