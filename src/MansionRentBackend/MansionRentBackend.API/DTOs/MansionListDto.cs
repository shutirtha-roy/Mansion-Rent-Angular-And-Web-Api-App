using Autofac;
using MansionRentBackend.Application.Services;
using MansionBO = MansionRentBackend.Application.BusinessObjects.Mansion;

namespace MansionRentBackend.API.DTOs;

public class MansionListDto : BaseDto
{
    private IMansionService _mansionService;

    public MansionListDto(IMansionService mansionService)
    {
        _mansionService = mansionService;
    }

    public override void ResolveDependency(ILifetimeScope scope)
    {
        base.ResolveDependency(scope);
        _mansionService = _scope.Resolve<IMansionService>();
    }

    internal async Task<MansionBO> GetMansion(Guid id)
    {
        var mansion = await _mansionService.GetMansion(id);
        return mansion;
    }

    internal async Task<IList<MansionBO>> GetAllVillas()
    {
        var mansions = await _mansionService.GetMansions();
        return mansions;
    }

    internal async Task<IList<MansionBO>> GetAllMansionsByPage(int pageSize, int pageNumber, int? occupancy, string? search)
    {
        var mansions = await _mansionService.GetAllWithRespectToPage(pageSize, pageNumber);

        if (occupancy > 0)
        {
            mansions = mansions.Where(o => o.Occupancy == occupancy).ToList();
        }

        if (!string.IsNullOrEmpty(search))
        {
            mansions = mansions.Where(u => u.Name.ToLower().Contains(search)).ToList();
        }

        return mansions;
    }

    internal async Task DeleteMansion(Guid id)
    {
        await _mansionService.DeleteMansion(id);
    }
}