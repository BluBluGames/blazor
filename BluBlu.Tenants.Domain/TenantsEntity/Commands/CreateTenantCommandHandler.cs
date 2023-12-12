using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BluBlu.Tenants.Domain.TenantsEntity.Commands;

public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, Tenant>
{
    private readonly ITenantsRepository _tenantsRepository;

    public CreateTenantCommandHandler(ITenantsRepository tenantsRepository)
    {
        _tenantsRepository = tenantsRepository;
    }

    public async Task<Tenant> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        await _tenantsRepository.CreateSchemaForTenant(request.Tenant);
        await _tenantsRepository.CreateTenantTablesAsync(request.Tenant);
        return await _tenantsRepository.Create(request.Tenant);
    }
}