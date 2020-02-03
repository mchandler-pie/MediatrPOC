using MediatR;
using MediatrPOC.Mediatr;

namespace MediatrPOC.Services
{
    public class PieMediatorService : IPieMediatorService
    {
        private readonly IMediator _mediator;

        public PieMediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Notify(string notifyText)
        {
            _mediator.Publish(new NotificationMessage {NotifyText = notifyText});
        }
    }
}
