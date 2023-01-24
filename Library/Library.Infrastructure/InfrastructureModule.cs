using Autofac;
using Library.Infrastructure.DbContexts;
using Library.Infrastructure.Repositories;
using Library.Infrastructure.Services;
using Library.Infrastructure.UnitOfWorks;

namespace Library.Infrastructure
{
    public class InfrastructureModule: Module
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

            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookService>().As<IBookService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookRepository>().As<IBookRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EBookService>().As<IEBookService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EBookRepository>().As<IEBookRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookDetailsService>().As<IBookDetailsService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookDetailsRepository>().As<IBookDetailsRepository>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
