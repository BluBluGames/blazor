using BluBlu.Tenants.Domain.TenantsEntity;
using BluBlu.Tenants.Infrastructure;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace BluBlu.Invoices.Infrastructure.Invoices;

public class TenantsRepository : ITenantsRepository
{
    private string _connectionString;

    public TenantsRepository(IOptions<DapperDbSettings> databaseSettings)
    {
        _connectionString = databaseSettings.Value.ConnectionString;
    }

    public async Task<Tenant> Create(Tenant tenant)
    {
        if (tenant == null)
            throw new ArgumentNullException(nameof(tenant));

        string sql = @$"
            INSERT INTO {tenant.Schema}.Tenants (Id, Name, Schema)
            VALUES (@Id, @Name, @Schema)
            RETURNING *";

        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);

        dbConnection.Open();

        return await dbConnection.QuerySingleAsync<Tenant>(sql, tenant);
    }

    public TenantsRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task CreateSchemaForTenant(Tenant tenant)
    {
        string sql = @$"CREATE SCHEMA IF NOT EXISTS {tenant.Schema};";

        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
        dbConnection.Open();

        await dbConnection.ExecuteAsync(sql);
    }

    public async Task CreateTenantTablesAsync(Tenant tenant)
    {
        string sql = 
        $@"
        CREATE TABLE IF NOT EXISTS {tenant.Schema}.Tenants
        (
            Id UUID PRIMARY KEY,
            Name VARCHAR(250) NOT NULL,
            Schema VARCHAR(60) NOT NULL,
            CreatedDate TIMESTAMP NOT NULL DEFAULT NOW(),
            UpdatedDate TIMESTAMP NOT NULL DEFAULT NOW()
        );

        CREATE TABLE IF NOT EXISTS {tenant.Schema}.Users
        (
            Id UUID PRIMARY KEY,
            Username VARCHAR(50) NOT NULL,
            FirstName VARCHAR(50) NOT NULL,
            LastName VARCHAR(50) NOT NULL,
            Email VARCHAR(100) NOT NULL,
            CreatedDate TIMESTAMP NOT NULL DEFAULT NOW(),
            UpdatedDate TIMESTAMP NOT NULL DEFAULT NOW()
        );

        CREATE TABLE IF NOT EXISTS {tenant.Schema}.Products
        (
            Id UUID PRIMARY KEY,
            Name VARCHAR(100) NOT NULL,
            PriceNet DECIMAL(18, 2) NOT NULL,
            UnitName VARCHAR(20) NOT NULL,
            Vat DECIMAL(5, 2) NOT NULL,
            IsVatZw BOOLEAN NOT NULL,
            PriceGross DECIMAL(18, 2),
            LegalBasisForTaxExemption VARCHAR(50),
            CreatedBy UUID NOT NULL,
            CreatedDate TIMESTAMP NOT NULL DEFAULT NOW(),
            UpdatedBy UUID NOT NULL,
            UpdatedDate TIMESTAMP NOT NULL DEFAULT NOW(),
            CONSTRAINT FK_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES {tenant.Schema}.Users(Id),
            CONSTRAINT FK_UpdatedBy FOREIGN KEY (UpdatedBy) REFERENCES {tenant.Schema}.Users(Id)
        );

        CREATE TABLE IF NOT EXISTS {tenant.Schema}.Contractors
        (
            Id UUID PRIMARY KEY,
            Name VARCHAR(100) NOT NULL,
            AddressStreet VARCHAR(255),
            AddressPostCity VARCHAR(100),
            AddressCountry VARCHAR(100),
            AddressPostCode VARCHAR(10),
            AddressBuildingNumber VARCHAR(20),
            AddressFlatNumber VARCHAR(10),
            Nip VARCHAR(15),
            NipPrefix VARCHAR(5),
            CreatedBy UUID NOT NULL,
            CreatedDate TIMESTAMP NOT NULL DEFAULT NOW(),
            UpdatedBy UUID NOT NULL,
            UpdatedDate TIMESTAMP NOT NULL DEFAULT NOW(),
            CONSTRAINT FK_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES {tenant.Schema}.Users(Id),
            CONSTRAINT FK_UpdatedBy FOREIGN KEY (UpdatedBy) REFERENCES {tenant.Schema}.Users(Id)
        );

        CREATE TABLE IF NOT EXISTS {tenant.Schema}.Invoices
        (
            Id UUID PRIMARY KEY,
            InvoiceNumber VARCHAR(20) NOT NULL,
            Currency VARCHAR(3) NOT NULL,
            SelectedLanguage VARCHAR(10) NOT NULL,
            SelectedLogo VARCHAR(100),
            DateOfInvoice DATE NOT NULL,
            DateOfRelease DATE,
            DateOfPayment DATE,
            FormOfPayment VARCHAR(50),
            AccountPrefix VARCHAR(10),
            AccountNumber VARCHAR(20) NOT NULL,
            BicSwift VARCHAR(15),
            IsPaymentDivided BOOLEAN NOT NULL,
            IsPaid BOOLEAN NOT NULL,
            Remarks TEXT,
            SellerId UUID,
            BuyerId UUID,
            CreatedBy UUID NOT NULL,
            CreatedDate TIMESTAMP NOT NULL DEFAULT NOW(),
            UpdatedBy UUID NOT NULL,
            UpdatedDate TIMESTAMP NOT NULL DEFAULT NOW(),
            CONSTRAINT FK_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES {tenant.Schema}.Users(Id),
            CONSTRAINT FK_UpdatedBy FOREIGN KEY (UpdatedBy) REFERENCES {tenant.Schema}.Users(Id),
            CONSTRAINT FK_Seller FOREIGN KEY (SellerId) REFERENCES {tenant.Schema}.Contractors(Id),
            CONSTRAINT FK_Buyer FOREIGN KEY (BuyerId) REFERENCES {tenant.Schema}.Contractors(Id)
        );


        CREATE TABLE IF NOT EXISTS {tenant.Schema}.InvoiceProducts
        (
            Id UUID PRIMARY KEY,
            InvoiceId UUID NOT NULL,
            ProductId UUID NOT NULL,
            NumberOfUnits INT NOT NULL,
            CreatedBy UUID NOT NULL,
            CreatedDate TIMESTAMP NOT NULL DEFAULT NOW(),
            UpdatedBy UUID NOT NULL,
            UpdatedDate TIMESTAMP NOT NULL DEFAULT NOW(),
            CONSTRAINT FK_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES {tenant.Schema}.Users(Id),
            CONSTRAINT FK_UpdatedBy FOREIGN KEY (UpdatedBy) REFERENCES {tenant.Schema}.Users(Id),
            CONSTRAINT FK_Invoice FOREIGN KEY (InvoiceId) REFERENCES {tenant.Schema}.Invoices(Id),
            CONSTRAINT FK_Product FOREIGN KEY (ProductId) REFERENCES {tenant.Schema}.Products(Id)
        );
        ";

        using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);

        dbConnection.Open();

        await dbConnection.ExecuteAsync(sql);
    }
}