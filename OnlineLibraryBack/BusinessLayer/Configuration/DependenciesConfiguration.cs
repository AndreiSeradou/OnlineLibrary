using OnlineLibrary.BusinessLayer.Interfaces.Services;
using OnlineLibrary.BusinessLayer.Mapping;
using OnlineLibrary.BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineLibrary.BusinessLayer.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection RegisterService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ILibrarianService, LibrarianService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddSingleton<IEmailSenderService, EmailSenderService>();
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
