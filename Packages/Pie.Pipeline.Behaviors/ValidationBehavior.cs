using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Packages.Pie.Pipeline.Messages;
using Packages.Pie.Pipeline.Responses;

namespace Packages.Pie.Pipeline.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ValidateQuoteRequestCommand
        where TResponse : QuoteRequestPipelineResponse
    {
        private readonly IEnumerable<IValidator<ValidateQuoteRequestCommand>> _validators;
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

        public ValidationBehavior(IEnumerable<IValidator<ValidateQuoteRequestCommand>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("Running input validations for {QuoteId}", request.Id);
            var context = new ValidationContext(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToArray();

            return failures.Any() 
                ? (TResponse)new QuoteRequestPipelineResponse {ValidationFailures = failures} 
                : await next();
        }
    }
}
