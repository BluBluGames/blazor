using BluBlu.Stocks.Common.Enums;
using BluBlu.Stocks.Domain.StockEntity;
using MediatR;

namespace BluBlu.Stocks.Domain.Services.PriceValuationService.GetStockPriceValuation;

public class GetStockPriceValuationQueryHandler : IRequestHandler<GetStockPriceValuationByIdQuery, StockPriceValuation>
{
    private readonly IStockRepository _stockRepository;

    public GetStockPriceValuationQueryHandler(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<StockPriceValuation> Handle(GetStockPriceValuationByIdQuery request, CancellationToken cancellationToken)
    {
        var stock = await _stockRepository.FetchStockById(request.Id);

        var returnObject = new StockPriceValuation();
        returnObject.PEValuation = stock.PE.Value switch
        {
            <= 5 => PEValuation.GreatDeal,
            > 5 and <= 8 => PEValuation.Cheap,
            > 8 and <= 16 => PEValuation.Neutral,
            > 16 and <= 20 => PEValuation.Expensive,
            > 20 => PEValuation.BubbleTerritory
        };
        returnObject.CAPEValuation = stock.CAPE.Value switch
        {
            <= 12 => CAPEValuation.GreatDeal,
            > 12 and <= 16 => CAPEValuation.Cheap,
            > 16 and <= 21 => CAPEValuation.Neutral,
            > 21 => CAPEValuation.Expensive
        };
        returnObject.ROEValuation = stock.ROE.Value switch
        {
            <= 10 => ROEValuation.Bad,
            > 10 and <= 20 => ROEValuation.Neutral,
            > 20 and <= 30 => ROEValuation.Good,
            > 30 => ROEValuation.VeryGood
        };
        returnObject.DividendYield = stock.DividendYield.Value;

        returnObject.FScoreValuation = stock.FScore.Value switch
        {
            <= 2 => FScoreValuation.Bad,
            > 2 and <= 4 => FScoreValuation.Neutral,
            > 4 and <= 6 => FScoreValuation.Good,
            > 6 => FScoreValuation.VeryGood
        };

        returnObject.DividendYieldValuation = stock.DividendYield.Value switch
        {
            <= 4 => DividendYieldValuation.Bad,
            > 4 and <= 7 => DividendYieldValuation.Neutral,
            > 7 and <= 12 => DividendYieldValuation.Good,
            > 12 => DividendYieldValuation.VeryGood
        };

        returnObject.Country = stock.Country;

        //TODO PBVValuation and PSValuation are calulated based on other factors
        //PSValuation should be calculated by comparing companies from same sector
        //PSValuation should be calculated by comparing comparing to country based on historic data
        //PBVValuation should be calculated by sector

        return returnObject;
    }
}