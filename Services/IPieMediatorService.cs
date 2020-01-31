using MediatR;

namespace MediatrPOC.Services
{
    public interface IPieMediatorService
    {
        void Notify(string notifyText);

    }
}
