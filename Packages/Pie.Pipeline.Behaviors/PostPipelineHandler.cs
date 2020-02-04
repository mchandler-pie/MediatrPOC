using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Packages.Pie.Pipeline.Messages;
using Packages.Pie.Pipeline.Responses;

namespace Packages.Pie.Pipeline.Behaviors
{
    public class PostPipelineHandler<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
        where TRequest :ValidateQuoteRequestCommand
        where TResponse: QuoteRequestPipelineResponse
    {
        private readonly ILogger<PostPipelineHandler<TRequest, TResponse>> _logger;

        public PostPipelineHandler(ILogger<PostPipelineHandler<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Completed handling quote {QuoteId}.", request.Id);

            if (!response.ValidationFailures.Any())
            {
                //TODO: Publish command to bus to persist final quote response.
            }

            return Task.CompletedTask;
        }
    }
}
