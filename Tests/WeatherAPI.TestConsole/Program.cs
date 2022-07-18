using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;
using WeatherAPI.CurrentWeather;
using WeatherAPI.HistoryWeather;
using WeatherAPI.LocationSearch;

namespace WeatherAPI.TestConsole
{
    public class Program
    {
        private static readonly IHost _hosting;

        public static IHost Hosting = _hosting ??= CreateHostBuilder(
            Environment.GetCommandLineArgs())
            .Build();

        private static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(ConfigureHost)
            .ConfigureServices(ConfigureServices);

        private static void ConfigureHost(IConfigurationBuilder builder) => builder
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>();

        public static IServiceProvider Services = Hosting.Services;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services
                .AddHttpClient<WeatherApiClient>(client =>
                {
                    var builder = new UriBuilder(host.Configuration["WeatherApi"]);
                    NameValueCollection query = HttpUtility.ParseQueryString(builder.Query);
                    query["key"] = host.Configuration["WeatherApiKeys:Default"];
                    builder.Query = query.ToString() ?? string.Empty;
                    client.BaseAddress = new Uri(builder.ToString());
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            var jitter = new Random();
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(6, retryAttempt => 
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) + 
                    TimeSpan.FromMilliseconds(jitter.Next(0, 1000)));
        }

        static async Task Main(string[] args)
        {
            using IHost host = Hosting;
            await host.StartAsync();

            var weather = host.Services.GetRequiredService<WeatherApiClient>();

            FoundLocation[] location = await weather.GetLocationByName("tomsk");
            CurrentWeatherResult currentWeather = await weather.GetCurrentWeather(
                location[0].Coordinates, "ru");
            SevenDayWeatherHistory weatherHistory = await weather.GetSevenDayWeatherHistory(
                "London", "2022-07-15");

            Console.WriteLine("Done!");
            Console.ReadLine();

            await host.StopAsync();
        }
    }
}
