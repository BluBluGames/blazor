using BluBlu.Tenants.Domain.UsersEntity;
using BluBlu.Tenants.Infrastructure;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace BluBlu.Invoices.Infrastructure.Invoices;

public class UsersRepository : IUsersRepository
{
    private string _connectionString;

    public UsersRepository(IOptions<DapperDbSettings> databaseSettings)
    {
        _connectionString = databaseSettings.Value.ConnectionString;
    }

    public async Task<User> Create(User user, string schema)
    {
        if (string.IsNullOrWhiteSpace(schema))
            throw new ArgumentNullException(nameof(schema));

        // Define your SQL query to insert the tenant into the specific schema
        string sql = @$"
            INSERT INTO {schema}.Users (Id, Username, FirstName, LastName, Email)
            VALUES (@Id, @Username, @FirstName, @LastName, @Email)
            RETURNING *";

        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);

        dbConnection.Open();

        return await dbConnection.QuerySingleAsync<User>(sql, user);
    }
}