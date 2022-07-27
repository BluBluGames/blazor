using MediatR;
using MongoDB.Driver;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity.Commands.Delete;

public class DeleteCountryCommand : IRequest<DeleteResult>
{
    public string Id { get; set; } = null!;
}