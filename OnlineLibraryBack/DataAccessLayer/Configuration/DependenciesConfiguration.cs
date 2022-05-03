using System;
using OnlineLibrary.DataAccessLayer.Data;
using OnlineLibrary.DataAccessLayer.Interfaces.Repositories;
using OnlineLibrary.DataAccessLayer.Mapping;
using OnlineLibrary.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineLibrary.DataAccessLayer.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            serviceCollection.AddScoped<IBookRepository, BookRepository>();

            return serviceCollection;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection serviceProvider, string connectionString)
        {
            serviceProvider.AddDbContext<ApiDbContext>(
                options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("OnlineLibraryPresentationLayer")));


            return serviceProvider;
        }

        public static IServiceCollection RegisterDLMappingConfig(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(
                c => c.AddProfile<MappingDLConfiguration>(),
                typeof(MappingDLConfiguration));

            return serviceCollection;
        }
    }
}
