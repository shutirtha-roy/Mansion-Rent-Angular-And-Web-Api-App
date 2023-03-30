using MansionBO = MansionRentBackend.Application.BusinessObjects.Mansion;
using MansionEO = MansionRentBackend.Domain.Entities.Mansion;

namespace MansionRentBackend.Application.Services
{
    public interface IMansionService
    {
        Task CreateMansion(MansionBO mansion);
        Task EditMansion(MansionBO mansion);
        Task DeleteMansion(Guid id);
        Task<MansionBO> GetMansion(Guid id);
        Task<IList<MansionBO>> GetMansions();
    }
}