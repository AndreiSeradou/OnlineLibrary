using Configuration.GeneralConfiguration;
using Microsoft.Extensions.DependencyInjection;
using OnlineLibraryPresentationLayer.Mapping;
using OnlineLibraryPresentationLayer.Quartz.Jobs;
using OnlineLibraryPresentationLayer.Quartz.Service;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace OnlineLibraryPresentationLayer.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection RegisterPLMappingConfig(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<QuartzHostedService>();
            serviceCollection.AddSingleton<IJobFactory, SingletonJobFactory>();
            serviceCollection.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            serviceCollection.AddSingleton<JobReminders>();
            serviceCollection.AddSingleton(new MyJob(type: typeof(JobReminders), expression: GeneralConfiguration.Expression));     
            serviceCollection.AddAutoMapper(
                c => c.AddProfile<MappingPLConfiguration>(),
                typeof(MappingPLConfiguration));

            return serviceCollection;
        }
    }
}
