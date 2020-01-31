using MediatR;
using Pie.Quote.Messages.Contracts.Post;

namespace MediatrPOC.Messages
{
    public class ValidateQuoteRequestCommand : IRequest<QuoteContactPost>
    {
        public QuoteContactPost request { get; set; }
    }
}
