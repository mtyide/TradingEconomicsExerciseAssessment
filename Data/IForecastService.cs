
namespace TradingEconomicsExerciseAssessment.Data
{
    public interface IForecastService
    {
        Task<IEnumerable<Forecast>?> GetForecast(string country);
    }
}