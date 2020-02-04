using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Packages.Pie.Pipeline.Messages;
using Packages.Pie.Pipeline.Responses;
using Pie.Quote.Messages.Contracts;

namespace Packages.Pie.Pipeline.Behaviors
{
    public class RatingHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ValidateQuoteRequestCommand
        where TResponse : QuoteRequestPipelineResponse
    {
        private readonly ILogger<RatingHandler<TRequest, TResponse>> _logger;

        public RatingHandler(ILogger<RatingHandler<TRequest, TResponse>> _logger)
        {
            this._logger = _logger;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("Running rating for {QuoteId}", request.Id);

            var quote = (TResponse)new QuoteRequestPipelineResponse
            {
                QuoteResponse = new QuoteResponse {Id = request.Id, PremiumDetails = { PolicyTotalEstimatedCost = 10000000m}}
            };

            return Task.FromResult(quote);
        }
    }
}