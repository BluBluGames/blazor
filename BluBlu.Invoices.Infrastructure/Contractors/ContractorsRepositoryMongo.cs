using BluBlu.Invoices.Domain.ContractorsEntity;
using BluBlu.Invoices.Infrastructure.Connection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BluBlu.Invoices.Infrastructure.Contractors;

public class ContractorsRepositoryMongo : IContractorsRepositoryMongo
{
    private readonly IInvoicesDatabaseMongo _database;

    public ContractorsRepositoryMongo(IInvoicesDatabaseMongo database)
    {
        _database = database;
    }

    public async Task<Contractor> CreateContractor(Contractor contractor)
    {
        contractor.Id = ObjectId.GenerateNewId().ToString();
        await _database.Contractors.InsertOneAsync(contractor);
        var idFilter = Builders<Contractor>.Filter.Eq(i => i.Id, contractor.Id);

        return await _database.Contractors.Find(idFilter).FirstOrDefaultAsync();
    }
}