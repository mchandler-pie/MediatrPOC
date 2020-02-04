using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Packages.Pie.Pipeline.Messages;
using Packages.Pie.Pipeline.Responses;
using Pie.Quote.Messages.Contracts;

namespace MediatrPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<ActionResult<QuoteRequestPipelineResponse>> PostAsync()
        {
            var request = new QuoteRequest();
            var result = await _mediator.Send(new ValidateQuoteRequestCommand{InitialRequest = request});

            return result.ValidationFailures?.Any() ?? false
                ? (ActionResult)BadRequest(result)
                : Created(string.Empty, result);
        }

    }
}