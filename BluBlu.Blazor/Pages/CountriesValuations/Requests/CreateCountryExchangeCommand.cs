using BluBlu.Stocks.Common.Enums;
using BluBlu.Stocks.Domain.CountryExchangeEntity.ValueObjects;
using static System.Enum;

namespace BluBlu.Blazor.Pages.CountriesValuations.Requests;

public class CreateCountryExchangeCommand
{
    public string Country { get; set; } = null!;
    public decimal PE { get; set; }
    public decimal CAPE { get; set; }
    public decimal PBV { get; set; }
    public decimal DividendYield { get; set; }
    public DateTime YearOfCalculation { get; set; } = DateTime.Today;

    public BluBlu.Stocks.Domain.CountryExchangeEntity.CountryExchange ToDomainModel()
    {
        return new(
            new(Country),
            new(YearOfCalculation),
            new(PE),
            new(CAPE),
            new(PBV),
            new(DividendYield)
        );
    }
}