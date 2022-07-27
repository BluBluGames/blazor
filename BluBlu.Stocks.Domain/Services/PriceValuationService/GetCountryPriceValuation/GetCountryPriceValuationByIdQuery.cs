using MediatR;

namespace BluBlu.Stocks.Domain.Services.PriceValuationService.GetCountryPriceValuation;

public class GetCountryPriceValuationByIdQuery : IRequest<CountryPriceValuationResponse>
{
    public string Id { get; set; } = null!;
}