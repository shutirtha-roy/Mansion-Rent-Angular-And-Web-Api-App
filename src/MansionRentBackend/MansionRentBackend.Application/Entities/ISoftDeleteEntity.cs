namespace MansionRentBackend.Application.Entities;

public interface ISoftDeleteEntity
{
    bool IsDeleted { get; set; }
}