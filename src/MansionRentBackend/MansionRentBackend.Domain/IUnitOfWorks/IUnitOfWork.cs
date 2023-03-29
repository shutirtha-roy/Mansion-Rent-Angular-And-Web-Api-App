namespace MansionRentBackend.Domain.IUnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}