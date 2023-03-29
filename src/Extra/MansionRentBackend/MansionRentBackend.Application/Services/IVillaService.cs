using MansionBO = MansionRentBackend.Application.BusinessObjects.Mansion;
using MansionEO = MansionRentBackend.Application.Entities.Mansion;

namespace MansionRentBackend.Application.Services
{
    public interface IVillaService
    {
        Task CreateVilla(MansionBO villa);
        Task EditVilla(MansionBO villa);
        Task DeleteVilla(Guid id);
        Task<MansionBO> GetVilla(Guid id);
        Task<IList<MansionBO>> GetVillas();
        Task<IList<MansionBO>> GetAllWithRespectToPage(int pageSize, int pageNumber);
    }
}