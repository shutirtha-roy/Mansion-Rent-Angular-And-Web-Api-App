namespace MansionRentBackend.Application.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}