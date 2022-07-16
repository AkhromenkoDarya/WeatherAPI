using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherAPI.Current;

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
            services.AddHttpClient<WeatherApiClient>(client =>
            {
                var builder = new UriBuilder(host.Configuration["WeatherApi"]);
                NameValueCollection query = HttpUtility.ParseQueryString(builder.Query);
                query["key"] = "4929b73f9c8943dba9265546221607";
                builder.Query = query.ToString();
                client.BaseAddress = new Uri(builder.ToString());

                //client.BaseAddress = new Uri(host.Configuration["WeatherApi"]);
                client.DefaultRequestVersion = HttpVersion.Version10;
            });
        }

        static async Task Main(string[] args)
        {
            using IHost host = Hosting;
            await host.StartAsync();

            var weather = host.Services.GetRequiredService<WeatherApiClient>();

            Location[] location = await weather.GetLocationByName("tomsk");
            CurrentWeather currentWeather = await weather.GetCurrentWeatherByCoordinates(
                location[0].Latitude, location[0].Longitude);

            Console.WriteLine("Done!");
            Console.ReadLine();

            await host.StopAsync();
        }
    }
}
