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
        //private readonly IValidator _validator;
        //public ValidateQuoteRequestHandler(IValidator validator)
        //{
        //    _validator = validator;
        //}

        public Task<QuoteRequestPipelineResponse> Handle(ValidateQuoteRequestCommand requestCommand, CancellationToken cancellationToken)
        {
            //_validator.Validate(requestCommand.InitialRequest);

            var response = new QuoteRequestPipelineResponse();
            return Task.FromResult(response);
        }
    }
}
