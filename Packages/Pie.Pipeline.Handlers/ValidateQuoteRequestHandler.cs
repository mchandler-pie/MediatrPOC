using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Packages.Pie.Pipeline.Messages;
using Packages.Pie.Pipeline.Responses;

namespace Packages.Pie.Pipeline.Handlers
{
    public class ValidateQuoteRequestHandler : IRequestHandler<ValidateQuoteRequestCommand, QuoteRequestPipelineResponse>
    {

        public Task<QuoteRequestPipelineResponse> Handle(ValidateQuoteRequestCommand requestCommand, CancellationToken cancellationToken)
        {
            var response = new QuoteRequestPipelineResponse();
            return Task.FromResult(response);
        }
    }
}
