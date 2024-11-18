using Newtonsoft.Json;
using RestSharp;

namespace TradingEconomicsExerciseAssessment.Data;

public class ForecastService : IForecastService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<ForecastService> _logger;
    private readonly IRestClient _restClient;

    public ForecastService(IConfiguration configuration, ILogger<ForecastService> logger, IRestClient restClient)
    {
        _configuration = configuration;
        _logger = logger;
        _restClient = restClient;
    }

    public async Task<IEnumerable<Forecast>?> GetForecast(string country)
    {
        try
        {
            var baseUri = Convert.ToString(_configuration["TradingEconomics:ApiEndPoint"]);
            var apiKey = Convert.ToString(_configuration["TradingEconomics:Key"]);

            var request = new RestRequest($"{baseUri}/forecast/country/{country}?c={apiKey}", Method.Get);

            var result = await _restClient.ExecuteAsync<Forecast>(request);

            if (result != null)
            {
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore,
                    FloatFormatHandling = FloatFormatHandling.DefaultValue
                };

                var content = result.Content ?? string.Empty;   

                return JsonConvert.DeserializeObject<IEnumerable<Forecast>>(content, settings) ?? null;
            }

            return null;
        }
        catch
        {
            _logger.LogError("Error while getting forecast data");
            throw;
        }
    }
}
