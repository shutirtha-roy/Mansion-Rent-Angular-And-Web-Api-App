using Autofac;
using MansionRentBackend.Application.Entities;
using MansionRentBackend.Application.Services;
using MansionRentBackend.Application.Services.Auth;
using Microsoft.AspNetCore.Identity;
using MansionBO = MansionRentBackend.Application.BusinessObjects.Mansion;

namespace MansionRentBackend.API.DTOs;

public class MansionListDto : BaseDto
{
    private IMansionService _mansionService;
    private readonly ApplicationUserManager _userManager;

    public MansionListDto(IMansionService mansionService, ApplicationUserManager userManager)
    {
        _mansionService = mansionService;
        _userManager = userManager;
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

    internal async Task<IList<MansionBO>> GetAllMansions()
    {
        var mansions = await _mansionService.GetMansions();
        return mansions;
    }

    internal async Task<IList<MansionBO>> GetAllMansionsByUser(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if(await _userManager.IsInRoleAsync(user, "Admin"))
        {
            return await GetAllMansions();
        }

        var mansions = await _mansionService.GetMansionsByUser(userId);
        return mansions;
    }

    internal async Task DeleteMansion(Guid id)
    {
        await _mansionService.DeleteMansion(id);
    }
}