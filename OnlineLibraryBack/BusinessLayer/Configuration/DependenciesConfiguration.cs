using BusinessLayer.Interfaces.Services;
using BusinessLayer.Mapping;
using BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection RegisterService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ILibrarianService, LibrarianService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterBLMappingConfig(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(
                c => c.AddProfile<MappingBLConfiguration>(),
                typeof(MappingBLConfiguration));

            return serviceCollection;
        }
    }
}
