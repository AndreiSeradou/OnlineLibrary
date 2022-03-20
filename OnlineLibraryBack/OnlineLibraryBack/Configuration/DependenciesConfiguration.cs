using System;
using Microsoft.Extensions.DependencyInjection;
using OnlineLibraryPresentationLayer.Mapping;

namespace OnlineLibraryPresentationLayer.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection RegisterPLMappingConfig(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(
                c => c.AddProfile<MappingPLConfiguration>(),
                typeof(MappingPLConfiguration));

            return serviceCollection;
        }
    }
}
