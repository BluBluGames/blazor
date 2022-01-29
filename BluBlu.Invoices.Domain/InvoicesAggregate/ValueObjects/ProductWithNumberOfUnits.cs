using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects.ProductVO;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

public class ProductWithNumberOfUnits
{
    [BsonElement("Product")] public Product Product { get; set; } = null!;
    [BsonElement("NumberOfUnits")] public NumberOfUnits NumberOfUnits { get; set; } = null!;
    
    public ProductWithNumberOfUnits()
    {
    }

    public ProductWithNumberOfUnits(Product product, NumberOfUnits numberOfUnits)
    {
        Product = product;
        NumberOfUnits = numberOfUnits;
    }

}