using System.Threading.Tasks;
using MediatR;
using MediatrPOC.Messages;
using MediatrPOC.Services;
using Microsoft.AspNetCore.Mvc;
using Pie.Quote.Messages.Contracts.Post;

namespace MediatrPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IPieMediatorService _pieMediatorService;
        private readonly IMediator _mediator;

        public QuotesController(IMediator mediator, IPieMediatorService pieMediatorService)
        {
            _pieMediatorService = pieMediatorService;
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<ActionResult<bool>> PostAsync([FromBody] QuoteRequestPost request)
        {
            var result = false;

            await _mediator.Send(new ValidateQuoteRequestCommand {request = request});

            _pieMediatorService.Notify("This is a test notification");

            return result;
        }

    }
}