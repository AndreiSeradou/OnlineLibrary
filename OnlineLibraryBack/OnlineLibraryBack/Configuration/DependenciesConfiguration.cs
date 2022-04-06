using OnlineLibrary.Configuration.GeneralConfiguration;
using Microsoft.Extensions.DependencyInjection;
using OnlineLibrary.PresentationLayer.Mapping;
using OnlineLibrary.PresentationLayer.Quartz.Jobs;
using OnlineLibrary.PresentationLayer.Quartz.HostedService;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using OnlineLibrary.PresentationLayer.Quartz.JobsFactory;

namespace OnlineLibrary.PresentationLayer.Configuration
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
