using BluBlu.Invoices.Domain.ContractorsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate;

public class Invoice
{
    [BsonId] [BsonRepresentation(BsonType.ObjectId)] [BsonIgnoreIfDefault] public string Id { get; set; } = null!;
    [BsonElement("InvoiceNumber")] public string InvoiceNumber { get; set; } = null!;
    [BsonElement("DateOfInvoice")] public DateTime DateOfInvoice { get; set; }
    [BsonElement("DateOfRelease")] public DateTime DateOfRelease { get; set; }
    [BsonElement("DateOfPayment")] public DateTime DateOfPayment { get; set; }
    [BsonElement("FormOfPayment")] public string FormOfPayment { get; set; } = null!;
    [BsonElement("AccountNumber")] public string AccountNumber { get; set; } = null!;
    [BsonElement("IsPaymentDivided")] public bool IsPaymentDivided { get; set; }
    [BsonElement("IsPaid")] public bool IsPaid { get; set; }
    [BsonElement("Remarks")] public string Remarks { get; set; } = null!;
    [BsonElement("Seller")] public Contractor Seller { get; set; } = null!;
    [BsonElement("Buyer")] public Contractor Buyer { get; set; } = null!;
    [BsonElement("Products")] public ICollection<Product> Products { get; set; } = null!;
}