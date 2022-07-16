using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using WeatherAPI.Current;

namespace WeatherAPI
{
    public class WeatherApiClient
    {
        private readonly HttpClient _client;

        public WeatherApiClient(HttpClient client) => _client = client;

        public async Task<Location[]> GetLocationByName(string locationName,
            CancellationToken cancellationToken = default)
        {
            var builder = new UriBuilder(_client.BaseAddress)
            {
                Path = "v1/search.json",
                Query = $"{_client.BaseAddress.Query}&q={locationName}"
            };

            return await _client
                .GetFromJsonAsync<Location[]>(builder.ToString(), cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<CurrentWeather> GetCurrentWeatherByCoordinates(decimal latitude, 
            decimal longitude, CancellationToken cancellationToken = default)
        {
            var builder = new UriBuilder(_client.BaseAddress)
            {
                Path = "v1/current.json",
                Query = $"{_client.BaseAddress.Query}&q=" +
                        $"{latitude.ToString(CultureInfo.InvariantCulture)}," +
                        $"{longitude.ToString(CultureInfo.InvariantCulture)}"
            };

            return await _client
                .GetFromJsonAsync<CurrentWeather>(builder.ToString(), cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
