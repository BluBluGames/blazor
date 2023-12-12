using BluBlu.Tenants.Domain.TenantsEntity;
using MediatR;

namespace BluBlu.Tenants.Domain.TenantsEntity.Commands;

public class CreateTenantCommand : IRequest<Tenant>
{
    public Tenant Tenant { get; set; } = null!;
}