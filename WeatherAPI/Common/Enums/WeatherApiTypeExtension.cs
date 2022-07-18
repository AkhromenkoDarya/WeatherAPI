namespace WeatherAPI.Common.Enums
{
    internal static class WeatherApiTypeExtension
    {
        internal static string GetResourcePath(this WeatherApiType apiType) => "/v1/" + 
            apiType.ToString().ToLower() + ".json";
    }
}
