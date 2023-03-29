namespace MansionRentBackend.Application.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}