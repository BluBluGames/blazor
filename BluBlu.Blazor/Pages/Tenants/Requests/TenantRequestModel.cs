using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;
using NuGet.Protocol.Plugins;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using System;

public class TenantRequestModel
{
    public Guid? Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Schema { get; set; } = null!;

    public BluBlu.Tenants.Domain.TenantsEntity.Tenant ToDomainModel()
    {
        return new(Id, new(Name), new(Schema));
    }
}