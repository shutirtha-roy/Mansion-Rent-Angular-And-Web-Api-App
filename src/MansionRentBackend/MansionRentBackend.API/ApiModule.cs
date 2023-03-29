using Autofac;
using MansionRentBackend.API.Model;

namespace MansionRentBackend.API
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VillaCreateModel>()
                .AsSelf();

            builder.RegisterType<VillaListModel>()
                .AsSelf();

            builder.RegisterType<VillaEditModel>()
                .AsSelf();

            builder.RegisterType<APIResponse>()
                .AsSelf();

            builder.RegisterType<PaginationModel>()
                .AsSelf();

            base.Load(builder);
        }
    }
}