using Autofac;
using MansionRentBackend.Application.Services;
using MansionBO = MansionRentBackend.Application.BusinessObjects.Mansion;

namespace MansionRentBackend.API.DTOs;

public class MansionListDto : BaseDto
{
    private IVillaService _villaService;

    public MansionListDto(IVillaService villaService)
    {
        _villaService = villaService;
    }

    public override void ResolveDependency(ILifetimeScope scope)
    {
        base.ResolveDependency(scope);
        _villaService = _scope.Resolve<IVillaService>();
    }

    internal async Task<MansionBO> GetMansion(Guid id)
    {
        var mansion = await _villaService.GetVilla(id);
        return mansion;
    }

    internal async Task<IList<MansionBO>> GetAllVillas()
    {
        var mansions = await _villaService.GetVillas();
        return mansions;
    }

    internal async Task<IList<MansionBO>> GetAllMansionsByPage(int pageSize, int pageNumber)
    {
        var mansions = await _villaService.GetAllWithRespectToPage(pageSize, pageNumber);
        return mansions;
    }

    internal async Task DeleteMansion(Guid id)
    {
        await _villaService.DeleteVilla(id);
    }
}