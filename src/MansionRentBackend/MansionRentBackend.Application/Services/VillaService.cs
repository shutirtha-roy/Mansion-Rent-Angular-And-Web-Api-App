using AutoMapper;
using MansionRentBackend.Application.UnitOfWorks;
using MansionBO = MansionRentBackend.Application.BusinessObjects.Mansion;
using MansionEO = MansionRentBackend.Application.Entities.Mansion;

namespace MansionRentBackend.Application.Services
{
    public class VillaService : IVillaService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public VillaService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task CreateVilla(MansionBO villa)
        {
            var count = await _applicationUnitOfWork.Villas.GetCount(x => x.Name.ToLower() == villa.Name.ToLower());

            if (count > 0)
                throw new Exception("Villa name already exists");

            var villaEntity = _mapper.Map<MansionEO>(villa);

            await _applicationUnitOfWork.Villas.Add(villaEntity);
            _applicationUnitOfWork.Save();
        }

        public async Task DeleteVilla(Guid id)
        {
            var count = await _applicationUnitOfWork.Villas.GetCount(x => x.Id == id);

            if (count == 0)
                throw new Exception("Villa doesn't exist");

            await _applicationUnitOfWork.Villas.Remove(id);
            _applicationUnitOfWork.Save();
        }

        public async Task EditVilla(MansionBO villa)
        {
            var villaEntity = await _applicationUnitOfWork.Villas.GetById(villa.Id);

            if (villaEntity == null)
                throw new Exception("Villa doesn't exist");

            villaEntity = _mapper.Map(villa, villaEntity);
            _applicationUnitOfWork.Save();
        }

        public async Task<MansionBO> GetVilla(Guid id)
        {
            var villaEntity = await _applicationUnitOfWork.Villas.GetById(id);

            if (villaEntity == null)
                throw new Exception("Villa doesn't exist");

            var villaBO = _mapper.Map<MansionBO>(villaEntity);

            return villaBO;
        }

        public async Task<IList<MansionBO>> GetVillas()
        {
            var villasEO = await _applicationUnitOfWork.Villas.GetAll();

            var villas = new List<MansionBO>();

            foreach(var villaEO in villasEO)
            {
                var villaBO = _mapper.Map<MansionBO>(villaEO);
                villas.Add(villaBO);
            }

            return villas;
        }

        public async Task<IList<MansionBO>> GetAllWithRespectToPage(int pageSize, int pageNumber)
        {
            var villasEO = await _applicationUnitOfWork.Villas.GetAllAccordingToPageAsync(null, "", pageSize, pageNumber);

            var villas = new List<MansionBO>();

            foreach (var villaEO in villasEO)
            {
                var villaBO = _mapper.Map<MansionBO>(villaEO);
                villas.Add(villaBO);
            }

            return villas;
        }
    }
}