using Autofac;
using MansionRentBackend.API.DTOs;

namespace MansionRentBackend.API;

public class ApiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MansionCreateDto>()
            .AsSelf();

        builder.RegisterType<MansionListDto>()
            .AsSelf();

        builder.RegisterType<MansionEditDto>()
            .AsSelf();

        builder.RegisterType<APIResponse>()
            .AsSelf();

        builder.RegisterType<PaginationDto>()
            .AsSelf();

        base.Load(builder);
    }
}