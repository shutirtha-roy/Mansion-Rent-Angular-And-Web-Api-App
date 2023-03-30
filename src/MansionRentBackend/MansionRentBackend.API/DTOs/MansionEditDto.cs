using Autofac;
using AutoMapper;
using MansionRentBackend.Application.Services;
using MantionBO = MansionRentBackend.Application.BusinessObjects.Mansion;

namespace MansionRentBackend.API.DTOs;

public class MansionEditDto : BaseDto
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

    private IMansionService _mansionService;
    private IMapper _mapper;

    public MansionEditDto() : base()
    {
    }

    public MansionEditDto(IMansionService mansionService, IMapper mapper)
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

    internal async Task<MansionEditDto> GetMansion(Guid id)
    {
        var mansion = await _mansionService.GetMansion(id);
        return _mapper.Map<MansionEditDto>(mansion);
    }

    internal async Task EditMansion(Guid userId)
    {
        var mansion = _mapper.Map<MantionBO>(this);
        mansion.UserId = userId;

        await _mansionService.EditMansion(mansion);
    }
}