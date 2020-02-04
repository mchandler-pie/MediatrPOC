using System;
using MediatR;
using Packages.Pie.Pipeline.Responses;
using Pie.Quote.Messages.Contracts.Post;

namespace Packages.Pie.Pipeline.Messages
{
    public class ValidateQuoteRequestCommand : IRequest<QuoteRequestPipelineResponse>
    {
        public Guid Id { get; set; }
        public QuoteRequestPost InitialRequest { get; set; }
        public decimal Score { get; set; }
    }
}
