using BluBlu.Stocks.Common.Enums;
using BluBlu.Stocks.Domain.StockEntity.ValueObjects;

namespace BluBlu.Stocks.Domain.Services.PriceValuationService.GetStockPriceValuation;

public class StockPriceValuation
{
    public Country Country { get; set; }
    public PEValuation PEValuation { get; set; }
    public CAPEValuation CAPEValuation { get; set; }
    public PSValuation PSValuation { get; set; }
    public PBVValuation PBVValuation { get; set; }
    public FScoreValuation FScoreValuation { get; set; }
    public ROEValuation ROEValuation { get; set; }
    public decimal DividendYield { get; set; }
    public DividendYieldValuation DividendYieldValuation { get; set; }
}