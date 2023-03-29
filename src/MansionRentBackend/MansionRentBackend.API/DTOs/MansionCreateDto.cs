using Autofac;
using AutoMapper;
using MansionRentBackend.Application.Services;
using VillaBO = MansionRentBackend.Application.BusinessObjects.Mansion;

namespace MansionRentBackend.API.DTOs;

public class MansionCreateDto : BaseDto
{
    public string Name { get; set; }
    public string? Details { get; set; }
    public double Rate { get; set; }
    public int Sqft { get; set; }
    public int Occupancy { get; set; }
    public string? Base64Image { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; } = false;

    private IMansionService _mansionService;
    private IMapper _mapper;

    public MansionCreateDto()
    {
    }

    public MansionCreateDto(IMansionService mansionService, IMapper mapper)
    {
        _mansionService = mansionService;
        _mapper = mapper;
    }

    public override void ResolveDependency(ILifetimeScope scope)
    {
        base.ResolveDependency(scope);
        _mansionService = _scope.Resolve<IMansionService>();
        _mapper = _scope.Resolve<IMapper>();
    }

    internal async Task CreateMantion()
    {
        var mansion = _mapper.Map<VillaBO>(this);

        await _mansionService.CreateMansion(mansion);
    }
}