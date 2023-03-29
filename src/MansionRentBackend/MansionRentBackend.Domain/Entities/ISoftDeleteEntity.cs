namespace MansionRentBackend.Domain.Entities;

public interface ISoftDeleteEntity
{
    bool IsDeleted { get; set; }
}