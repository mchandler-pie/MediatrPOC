using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Packages.Pie.Pipeline.Messages;
using Packages.Pie.Pipeline.Responses;

namespace Packages.Pie.Pipeline.Behaviors
{
    public class ScoringHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ValidateQuoteRequestCommand
        where TResponse : QuoteRequestPipelineResponse
    {
        private readonly ILogger<ScoringHandler<TRequest, TResponse>> _logger;

        public ScoringHandler(ILogger<ScoringHandler<TRequest, TResponse>> _logger)
        {
            this._logger = _logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("Scoring quote {QuoteId}", request.Id);
            request.Score = 1.03m;
            return await next();
        }
    }
}
