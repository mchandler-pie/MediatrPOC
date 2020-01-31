using MediatR;
using Pie.Quote.Messages.Contracts;
using Pie.Quote.Messages.Contracts.Post;

namespace MediatrPOC.Messages
{
    public class ValidateQuoteRequestCommand : IRequest<QuoteRequestPost>
    {
        public QuoteRequestPost request { get; set; }
    }
}
