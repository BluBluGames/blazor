using BluBlu.Stocks.Common.Enums;
using BluBlu.Stocks.Domain.StockEntity.ValueObjects;

namespace BluBlu.Stocks.Domain.Services.PriceValuationService.GetStockPriceValuation;

public class StockPriceValuation
{
    public Country Country { get; set; } = null!;
    public PEValuation PeValuation { get; set; }
    public CAPEValuation CapeValuation { get; set; }
    public PSValuation PsValuation { get; set; }
    public PBVValuation PbvValuation { get; set; }
    public FScoreValuation FScoreValuation { get; set; }
    public ROEValuation ROEValuation { get; set; }
    public decimal DividendYield { get; set; }
    public DividendYieldValuation DividendYieldValuation { get; set; }
}