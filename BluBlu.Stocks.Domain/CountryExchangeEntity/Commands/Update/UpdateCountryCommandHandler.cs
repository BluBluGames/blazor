using MediatR;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity.Commands.Update;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, CountryExchange>
{
    private readonly ICountryExchangeRepository _countryExchangeRepository;

    public UpdateCountryCommandHandler(ICountryExchangeRepository countryExchangeRepository)
    {
        _countryExchangeRepository = countryExchangeRepository;
    }

    public async Task<CountryExchange> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        return await _countryExchangeRepository.UpdateCountry(request.Id, request.CountryExchange);
    }
}