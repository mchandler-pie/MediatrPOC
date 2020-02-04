using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Packages.Pie.Pipeline.Messages;
using SequentialGuid;

namespace Packages.Pie.Pipeline.Behaviors
{
    public class PrePipelineHandler<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest: ValidateQuoteRequestCommand
    {
        private readonly ILogger<PrePipelineHandler<TRequest>> _logger;

        public PrePipelineHandler(ILogger<PrePipelineHandler<TRequest>> logger)
        {
            _logger = logger;
        }
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            //Assign the quote id right off the bat.
            request.Id = SequentialGuidGenerator.Instance.NewGuid();

            _logger.LogInformation("Begin handling quote request for {QuoteId}", request.Id); 

            //TODO: Publish command on the bus to persist to Mongo.
            
            return Task.CompletedTask;
        }
    }
}
