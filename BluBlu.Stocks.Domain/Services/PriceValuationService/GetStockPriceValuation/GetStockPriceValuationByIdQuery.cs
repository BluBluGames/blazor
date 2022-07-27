using MediatR;

namespace BluBlu.Stocks.Domain.Services.PriceValuationService.GetStockPriceValuation;

public class GetStockPriceValuationByIdQuery : IRequest<StockPriceValuation>
{
    public string Id { get; set; } = null!;
}