using MediatR;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity.Commands.Create;

public class CreateCountryExchangeCommandHandler : IRequestHandler<CreateCountryExchangeCommand, CountryExchange>
{
    private readonly ICountryExchangeRepository _countryExchangeRepository;

    public CreateCountryExchangeCommandHandler(ICountryExchangeRepository countryExchangeRepository)
    {
        _countryExchangeRepository = countryExchangeRepository;
    }

    public async Task<CountryExchange> Handle(CreateCountryExchangeCommand request, CancellationToken cancellationToken)
    {
        return await _countryExchangeRepository.CreateCountry(request.CountryExchange);
    }
}