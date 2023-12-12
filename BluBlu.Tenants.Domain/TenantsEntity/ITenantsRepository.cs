namespace BluBlu.Tenants.Domain.TenantsEntity;

public interface ITenantsRepository
{
    Task CreateSchemaForTenant(Tenant tenant);
    Task<Tenant> Create(Tenant tenant);
    Task CreateTenantTablesAsync(Tenant tenant);
}