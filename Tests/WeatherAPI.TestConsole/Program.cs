using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WeatherAPI.TestConsole
{
    public class Program
    {
        private static readonly IHost _hosting;

        public static IHost Hosting = _hosting ??= CreateHostBuilder(
            Environment.GetCommandLineArgs()).Build();

        private static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);

        public static IServiceProvider Services = Hosting.Services;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddHttpClient<WeatherApiClient>(client => client.BaseAddress = new Uri(
                host.Configuration["WeatherApi"]));
        }

        static async Task Main(string[] args)
        {
            using IHost host = Hosting;
            await host.StartAsync();

            var weather = host.Services.GetRequiredService<WeatherApiClient>();

            Console.WriteLine("Done!");
            Console.ReadLine();

            await host.StopAsync();
        }
    }
}
