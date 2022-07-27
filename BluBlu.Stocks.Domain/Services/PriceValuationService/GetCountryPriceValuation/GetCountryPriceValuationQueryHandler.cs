using BluBlu.Stocks.Common.Enums;
using BluBlu.Stocks.Domain.CountryExchangeEntity;
using MediatR;

namespace BluBlu.Stocks.Domain.Services.PriceValuationService.GetCountryPriceValuation;

public class GetCountryPriceValuationQueryHandler : IRequestHandler<GetCountryPriceValuationByIdQuery, CountryPriceValuationResponse>
{
    private readonly ICountryExchangeRepository _countryExchangeRepository;

    public GetCountryPriceValuationQueryHandler(ICountryExchangeRepository countryExchangeRepository)
    {
        _countryExchangeRepository = countryExchangeRepository;
    }

    public async Task<CountryPriceValuationResponse> Handle(GetCountryPriceValuationByIdQuery request, CancellationToken cancellationToken)
    {
        var stock = await _countryExchangeRepository.FetchCountryById(request.Id);
        
        return new CountryPriceValuationResponse
        {
            Name = stock.Country.ToString() ?? string.Empty,
            DividendYield = stock.DividendYield.Value,
            PEValuation = CalculatePEValuation(stock),
            CAPEValuation = CalculateCAPEValuation(stock),
            DividendYieldValuation = CalculateDividendYieldValuation(stock),
            PBVValuation = CalculatePBVValuation(stock)
        };
    }

    private PEValuation CalculatePEValuation(CountryExchange stock)
    {
        return stock.PE.Value switch
        {
            <= 5 => PEValuation.GreatDeal,
            > 5 and <= 8 => PEValuation.Cheap,
            > 8 and <= 16 => PEValuation.Neutral,
            > 16 and <= 20 => PEValuation.Expensive,
            > 20 => PEValuation.BubbleTerritory
        };
    }

    private CAPEValuation CalculateCAPEValuation(CountryExchange stock)
    {
        return stock.CAPE.Value switch
        {
            <= 12 => CAPEValuation.GreatDeal,
            > 12 and <= 16 => CAPEValuation.Cheap,
            > 16 and <= 21 => CAPEValuation.Neutral,
            > 21 => CAPEValuation.Expensive
        };
    }

    private DividendYieldValuation CalculateDividendYieldValuation(CountryExchange stock)
    {
        return stock.DividendYield.Value switch
        {
            <= 4 => DividendYieldValuation.Bad,
            > 4 and <= 7 => DividendYieldValuation.Neutral,
            > 7 and <= 12 => DividendYieldValuation.Good,
            > 12 => DividendYieldValuation.VeryGood
        };
    }

    private PBVValuation CalculatePBVValuation(CountryExchange stock)
    {
        return stock.PBV.Value switch
        {
            <= 4 => PBVValuation.Bad,
            > 4 and <= 7 => PBVValuation.Neutral,
            > 7 and <= 12 => PBVValuation.Good,
            > 12 => PBVValuation.VeryGood
        };
    }
}