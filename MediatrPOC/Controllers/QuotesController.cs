using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Packages.Messages;
using Pie.Quote.Messages.Contracts.Post;

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
        public async Task<ActionResult<QuoteRequestPost>> PostAsync([FromBody] QuoteRequestPost request)
        {

            try
            {
                var validationResult = await _mediator.Send(new ValidateQuoteRequestCommand
                    {request = request.Contacts.First()});

                request.PartnerAgentFirstName = "ValidateSuccess";

                //Next step in pipeline
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }

            return request;
        }

    }
}