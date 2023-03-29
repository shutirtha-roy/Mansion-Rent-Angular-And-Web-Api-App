using Autofac;
using MansionRentBackend.API.Model;

namespace MansionRentBackend.API
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MansionCreateDto>()
                .AsSelf();

            builder.RegisterType<VillaListModel>()
                .AsSelf();

            builder.RegisterType<MansionEditDto>()
                .AsSelf();

            builder.RegisterType<APIResponse>()
                .AsSelf();

            builder.RegisterType<PaginationModel>()
                .AsSelf();

            base.Load(builder);
        }
    }
}