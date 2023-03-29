using Autofac;
using MansionRentBackend.Application.Services;
using VillaBO = MansionRentBackend.Application.BusinessObjects.Mansion;

namespace MansionRentBackend.API.Model
{
    public class VillaListModel : BaseModel
    {
        private IVillaService _villaService;

        public VillaListModel(IVillaService villaService)
        {
            _villaService = villaService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _villaService = _scope.Resolve<IVillaService>();
        }

        internal async Task<VillaBO> GetVilla(Guid id)
        {
            var villa = await _villaService.GetVilla(id);
            return villa;
        }

        internal async Task<IList<VillaBO>> GetAllVillas()
        {
            var villas = await _villaService.GetVillas();
            return villas;
        }

        internal async Task<IList<VillaBO>> GetAllVillasByPage(int pageSize, int pageNumber)
        {
            var villas = await _villaService.GetAllWithRespectToPage(pageSize, pageNumber);
            return villas;
        }

        internal async Task DeleteVilla(Guid id)
        {
            await _villaService.DeleteVilla(id);
        }
    }
}