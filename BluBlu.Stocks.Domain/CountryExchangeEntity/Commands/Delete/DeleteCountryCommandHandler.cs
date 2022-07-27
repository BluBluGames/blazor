using MediatR;
using MongoDB.Driver;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity.Commands.Delete;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, DeleteResult>
{
    private readonly ICountryExchangeRepository _countryExchangeRepository;

    public DeleteCountryCommandHandler(ICountryExchangeRepository countryExchangeRepository)
    {
        _countryExchangeRepository = countryExchangeRepository;
    }

    public async Task<DeleteResult> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        return await _countryExchangeRepository.DeleteCountry(request.Id);
    }
}