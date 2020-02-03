using MediatR;
using Packages.Pie.Pipeline.Responses;
using Pie.Quote.Messages.Contracts.Post;

namespace Packages.Pie.Pipeline.Messages
{
    public class ValidateQuoteRequestCommand : IRequest<QuoteRequestPipelineResponse>
    {
        public QuoteRequestPost InitialRequest { get; set; }
    }
}
