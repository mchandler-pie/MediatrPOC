namespace MediatrPOC.Services
{
    public interface IPieMediatorService
    {
        void Notify(string notifyText);
        //Task<T> Send<T>(T request);
    }
}
