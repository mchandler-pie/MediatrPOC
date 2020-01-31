using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrPOC.Messages;
using Pie.Quote.Messages.Contracts;
using Pie.Quote.Messages.Contracts.Post;

namespace MediatrPOC.Handlers
{
    public class ValidateQuoteRequestHandler : IRequestHandler<ValidateQuoteRequestCommand, QuoteRequestPost>
    {
        public Task<QuoteRequestPost> Handle(ValidateQuoteRequestCommand requestCommand, CancellationToken cancellationToken)
        {
            var wtf = requestCommand;

            return Task.FromResult(requestCommand.request);
        }
    }
}
