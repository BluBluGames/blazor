using MediatR;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity.Commands.Create;

public class CreateCountryExchangeCommand : IRequest<CountryExchange>
{
    public CountryExchange CountryExchange { get; set; } = null!;
}