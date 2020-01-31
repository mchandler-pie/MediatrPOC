using MediatR;

namespace MediatrPOC.Mediatr
{
    public class NotificationMessage : INotification
    {
        public string NotifyText { get; set; }
    }
}
