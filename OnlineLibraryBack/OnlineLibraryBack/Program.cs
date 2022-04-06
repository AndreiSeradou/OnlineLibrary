using OnlineLibrary.Configuration.GeneralConfiguration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace OnlineLibrary.PresentationLayer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls(GeneralConfiguration.BaseUrl);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
