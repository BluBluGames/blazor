using BluBlu.Invoices.Domain.ContractorsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate;

public class Invoice
{
    [BsonId] [BsonRepresentation(BsonType.ObjectId)] [BsonIgnoreIfDefault] public string Id { get; set; } = null!;
    [BsonElement("InvoiceNumber")] public InvoiceNumber InvoiceNumber { get; set; } = new();
    [BsonElement("DateOfInvoice")] public DateOfInvoice DateOfInvoice { get; set; } = new();
    [BsonElement("DateOfRelease")] public DateOfRelease DateOfRelease { get; set; } = new();
    [BsonElement("DateOfPayment")] public DateOfPayment DateOfPayment { get; set; } = new();
    [BsonElement("FormOfPayment")] public FormOfPayment FormOfPayment { get; set; } = new();
    [BsonElement("AccountNumber")] public AccountNumber AccountNumber { get; set; } = new();
    [BsonElement("IsPaymentDivided")] public IsPaymentDivided IsPaymentDivided { get; set; } = new();
    [BsonElement("IsPaid")] public IsPaid IsPaid { get; set; } = new();
    [BsonElement("Remarks")] public Remarks? Remarks { get; set; }
    [BsonElement("Seller")] public Contractor Seller { get; set; } = new();
    [BsonElement("Buyer")] public Contractor Buyer { get; set; } = new();
    [BsonElement("Products")] public ICollection<ProductWithNumberOfUnits> Products { get; set; } = new List<ProductWithNumberOfUnits>();
    
    public Invoice()
    {
    }

    public Invoice(
        InvoiceNumber invoiceNumber,
        DateOfInvoice dateOfInvoice,
        DateOfRelease dateOfRelease,
        DateOfPayment dateOfPayment,
        FormOfPayment formOfPayment,
        AccountNumber accountNumber,
        IsPaymentDivided isPaymentDivided,
        IsPaid isPaid,
        Remarks? remarks,
        Contractor seller,
        Contractor buyer,
        ICollection<ProductWithNumberOfUnits> products)
    {
        InvoiceNumber = invoiceNumber;
        DateOfInvoice = dateOfInvoice;
        DateOfRelease = dateOfRelease;
        DateOfPayment = dateOfPayment;
        FormOfPayment = formOfPayment;
        AccountNumber = accountNumber;
        IsPaymentDivided = isPaymentDivided;
        IsPaid = isPaid;
        Remarks = remarks;
        Seller = seller;
        Buyer = buyer;
        Products = products;
    }
}