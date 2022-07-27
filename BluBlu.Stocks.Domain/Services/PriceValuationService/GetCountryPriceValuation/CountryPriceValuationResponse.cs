
using BluBlu.Stocks.Common.Enums;

namespace BluBlu.Stocks.Domain.Services.PriceValuationService.GetCountryPriceValuation;

public class CountryPriceValuationResponse
{
    public string Name { get; set; }
    public PEValuation PEValuation { get; set; }
    public PBVValuation PBVValuation { get; set; }
    public CAPEValuation CAPEValuation { get; set; }
    public decimal DividendYield { get; set; }
    public DividendYieldValuation DividendYieldValuation { get; set; }
}