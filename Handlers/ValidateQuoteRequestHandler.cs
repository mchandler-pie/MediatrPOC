using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrPOC.Messages;
using Pie.Quote.Messages.Contracts.Post;

namespace MediatrPOC.Handlers
{
    public class ValidateQuoteRequestHandler : IRequestHandler<ValidateQuoteRequestCommand, QuoteContactPost>
    {
        public Task<QuoteContactPost> Handle(ValidateQuoteRequestCommand requestCommand, CancellationToken cancellationToken)
        {
            return Task.FromResult(requestCommand.request);
        }
    }
}
