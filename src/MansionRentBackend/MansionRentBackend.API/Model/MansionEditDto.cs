using Autofac;
using AutoMapper;
using MansionRentBackend.Application.Services;
using VillaBO = MansionRentBackend.Application.BusinessObjects.Mansion;

namespace MansionRentBackend.API.Model
{
    public class MansionEditDto : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Details { get; set; }
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string? Base64Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        private IVillaService _villaService;
        private IMapper _mapper;

        public MansionEditDto() : base()
        {
        }

        public MansionEditDto(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _villaService = _scope.Resolve<IVillaService>();
            _mapper = _scope.Resolve<IMapper>();
        }

        internal async Task<MansionEditDto> GetMansion(Guid id)
        {
            var villa = await _villaService.GetVilla(id);
            return _mapper.Map<MansionEditDto>(villa);
        }

        internal async Task EditMansion()
        {
            var villa = _mapper.Map<VillaBO>(this);
            await _villaService.EditVilla(villa);
        }
    }
}