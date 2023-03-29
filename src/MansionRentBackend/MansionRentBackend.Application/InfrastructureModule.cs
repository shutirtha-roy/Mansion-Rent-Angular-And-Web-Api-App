using Autofac;
using MansionRentBackend.Application.DbContexts;
using MansionRentBackend.Application.Repositories;
using MansionRentBackend.Application.Services;
using MansionRentBackend.Application.Services.Auth;
using MansionRentBackend.Application.UnitOfWorks;
using MansionRentBackend.Domain.IUnitOfWorks;
using MansionRentBackend.Domain.Repositories;

namespace MansionRentBackend.Application
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InfrastructureModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<MansionService>()
                .As<IMansionService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MansionRepository>()
                .As<IMansionRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>()
                .As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserManager>().AsSelf();

            builder.RegisterType<ApplicationSignInManager>().AsSelf();

            builder.RegisterType<ApplicationRoleManager>().AsSelf();

            builder.RegisterType<AccountService>()
                .As<IAccountService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TokenService>()
                .As<ITokenService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}