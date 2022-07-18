using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using WeatherAPI.Common.Enums;
using WeatherAPI.CurrentWeather;
using WeatherAPI.HistoryWeather;
using WeatherAPI.LocationSearch;

namespace WeatherAPI
{
    public class WeatherApiClient
    {
        private readonly HttpClient _client;

        private readonly JsonSerializerOptions _options = new()
        {
            Converters =
            {
                new JsonStringEnumConverterWithAttributeSupport()
            }
        };

        public WeatherApiClient(HttpClient client) => _client = client;

        public async Task<FoundLocation[]> GetLocationByName(string locationName,
            CancellationToken cancellationToken = default)
        {
            UriBuilder builder = CreateUriBuilder(WeatherApiType.Search.GetResourcePath(), 
                $"&q={locationName}");

            return await _client
                .GetFromJsonAsync<FoundLocation[]>(builder.ToString(), cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<CurrentWeatherResult> GetCurrentWeather(string searchData,
            string conditionTextLanguage = "en", CancellationToken cancellationToken = default)
        {
            UriBuilder builder = CreateUriBuilder(WeatherApiType.Current.GetResourcePath(), 
                $"&q={searchData}&lang={conditionTextLanguage}");

            return await _client
                .GetFromJsonAsync<CurrentWeatherResult>(builder.ToString(), cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<SevenDayWeatherHistory> GetSevenDayWeatherHistory(string searchData,
            string outputDate, string conditionTextLanguage = "en", 
            CancellationToken cancellationToken = default)
        {
            if (!DateTime.TryParse(outputDate, CultureInfo.InvariantCulture, DateTimeStyles.None, 
                    out DateTime convertedToDateTime))
            {
                throw new FormatException("The input string was not in a correct format");
            }

            UriBuilder builder = CreateUriBuilder(WeatherApiType.History.GetResourcePath(),
                $"&q={searchData}&dt={convertedToDateTime}&lang={conditionTextLanguage}");

            return await _client
                .GetFromJsonAsync<SevenDayWeatherHistory>(builder.ToString(), _options, 
                    cancellationToken)
                .ConfigureAwait(false);
        }

        private UriBuilder CreateUriBuilder(string resourcePath, string queryData) =>
            new (_client.BaseAddress)
            {
                Path = resourcePath,
                Query = $"{_client.BaseAddress.Query}" + queryData
            };
    }
}
