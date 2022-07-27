namespace BluBlu.Stocks.Infrastructure.Connection;

public class StocksOptions
{
    public string StocksCollectionName { get; set; } = null!;
    public string CountriesExchangesCollectionName { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
    public string ConnectionStringDev { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}