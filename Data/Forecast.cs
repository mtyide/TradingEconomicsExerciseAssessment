namespace TradingEconomicsExerciseAssessment.Data;

public class Forecast
{
    public string? Category { get; set; }
    public string? Title { get; set; }
    public string? LatestValue { get; set; }
    public DateTime? LatestValueDate { get; set; }
    public decimal Q1 { get; set; }
    public decimal Q2 { get; set; }
    public decimal Q3 { get; set; }
    public decimal Q4 { get; set; }
    public decimal YearEnd { get; set; }
    public decimal YearEnd1 { get; set; }
    public decimal YearEnd2 { get; set; }
    public string? Frequency { get; set; }
    public string? Unit { get; set; }
    public string? HistoricalDataSymbol { get; set; }
}
