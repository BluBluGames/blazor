using BluBlu.Invoices.Domain.ContractorsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate;

public class Invoice
{
    [BsonId] [BsonRepresentation(BsonType.ObjectId)] [BsonIgnoreIfDefault] public string Id { get; set; } = null!;
    [BsonElement("InvoiceNumber")] public InvoiceNumber InvoiceNumber { get; set; } = null!;
    [BsonElement("DateOfInvoice")] public DateOfInvoice DateOfInvoice { get; set; } = null!;
    [BsonElement("DateOfRelease")] public DateOfRelease DateOfRelease { get; set; } = null!;
    [BsonElement("DateOfPayment")] public DateOfPayment DateOfPayment { get; set; } = null!;
    [BsonElement("FormOfPayment")] public FormOfPayment FormOfPayment { get; set; } = null!;
    [BsonElement("AccountNumber")] public AccountNumber AccountNumber { get; set; } = null!;
    [BsonElement("IsPaymentDivided")] public IsPaymentDivided IsPaymentDivided { get; set; } = null!;
    [BsonElement("IsPaid")] public IsPaid IsPaid { get; set; } = null!;
    [BsonElement("Remarks")] public Remarks? Remarks { get; set; } = null!;
    [BsonElement("Seller")] public Contractor Seller { get; set; } = null!;
    [BsonElement("Buyer")] public Contractor Buyer { get; set; } = null!;
    [BsonElement("Products")] public ICollection<ProductWithNumberOfUnits> Products { get; set; } = null!;
    
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