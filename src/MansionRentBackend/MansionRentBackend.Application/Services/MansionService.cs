using AutoMapper;
using MansionRentBackend.Application.UnitOfWorks;
using MansionBO = MansionRentBackend.Application.BusinessObjects.Mansion;
using MansionEO = MansionRentBackend.Application.Entities.Mansion;

namespace MansionRentBackend.Application.Services
{
    public class MansionService : IMansionService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public MansionService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task CreateMansion(MansionBO mansion)
        {
            var count = await _applicationUnitOfWork.Mansions.GetCount(x => x.Name.ToLower() == mansion.Name.ToLower());

            if (count > 0)
                throw new Exception("Mansion name already exists");

            var mansionEntity = _mapper.Map<MansionEO>(mansion);

            await _applicationUnitOfWork.Mansions.Add(mansionEntity);
            _applicationUnitOfWork.Save();
        }

        public async Task DeleteMansion(Guid id)
        {
            var count = await _applicationUnitOfWork.Mansions.GetCount(x => x.Id == id && x.IsDeleted == false);

            if (count == 0)
                throw new Exception("Mansion doesn't exist");

            var mansionEntity = await _applicationUnitOfWork.Mansions.GetById(id);
            mansionEntity.IsDeleted = true;

            _applicationUnitOfWork.Save();
        }

        public async Task EditMansion(MansionBO mansion)
        {
            var mansionEntity = await _applicationUnitOfWork.Mansions.GetById(mansion.Id);

            if (mansionEntity == null)
                throw new Exception("Mansion doesn't exist");

            mansion.UserId = mansionEntity.UserId;
            mansionEntity = _mapper.Map(mansion, mansionEntity);

            _applicationUnitOfWork.Save();
        }

        public async Task<MansionBO> GetMansion(Guid id)
        {
            var mantionEntity = await _applicationUnitOfWork.Mansions.GetById(id);

            if (mantionEntity == null)
                throw new Exception("Villa doesn't exist");

            var mantionBO = _mapper.Map<MansionBO>(mantionEntity);

            return mantionBO;
        }

        public async Task<IList<MansionBO>> GetMansions()
        {
            var mansionsEO = await _applicationUnitOfWork.Mansions.Get(x => x.IsDeleted == false, "");
            mansionsEO = mansionsEO.Take(100).ToList();

            var mansions = new List<MansionBO>();

            foreach (var mansionEO in mansionsEO)
            {
                var mansionBO = _mapper.Map<MansionBO>(mansionEO);
                mansions.Add(mansionBO);
            }

            return mansions;
        }

        public async Task<IList<MansionBO>> GetMansionsByUser(Guid userId)
        {
            var mansionsEO = await _applicationUnitOfWork.Mansions.Get(x => x.IsDeleted == false && x.UserId == userId, "");
            mansionsEO = mansionsEO.Take(100).ToList();

            var mansions = _mapper.Map<List<MansionBO>>(mansionsEO);

            return mansions;
        }
    }
}