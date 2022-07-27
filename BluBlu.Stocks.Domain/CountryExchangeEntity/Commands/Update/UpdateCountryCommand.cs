using MediatR;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity.Commands.Update;

public class UpdateCountryCommand : IRequest<CountryExchange>
{
    public string Id { get; set; } = null!;
    public CountryExchange CountryExchange { get; set; } = null!;
}