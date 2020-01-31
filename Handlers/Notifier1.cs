using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrPOC.Mediatr;

namespace MediatrPOC.Handlers
{
    public class Notifier1 : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Debugging from Notifier 1. Message  : {notification.NotifyText} ");
            return Task.CompletedTask;
        }
    }
}
