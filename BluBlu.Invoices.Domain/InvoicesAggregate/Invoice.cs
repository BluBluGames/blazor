using BluBlu.Invoices.Domain.ContractorsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate;

public class Invoice
{
    [BsonId] [BsonRepresentation(BsonType.ObjectId)] [BsonIgnoreIfDefault] public string Id { get; set; } = null!;
    [BsonElement("InvoiceNumber")] public InvoiceNumber InvoiceNumber { get; set; } = new();
    [BsonElement("SelectedLanguage")] public SelectedLanguage SelectedLanguage { get; set; } = new();
    [BsonElement("SelectedLogo")] public SelectedLogo SelectedLogo { get; set; } = new();
    [BsonElement("DateOfInvoice")] public DateOfInvoice DateOfInvoice { get; set; } = new();
    [BsonElement("DateOfRelease")] public DateOfRelease DateOfRelease { get; set; } = new();
    [BsonElement("DateOfPayment")] public DateOfPayment DateOfPayment { get; set; } = new();
    [BsonElement("FormOfPayment")] public FormOfPayment FormOfPayment { get; set; } = new();
    [BsonElement("AccountPrefix")] public AccountPrefix? AccountPrefix { get; set; } = new();
    [BsonElement("AccountNumber")] public AccountNumber AccountNumber { get; set; } = new();
    [BsonElement("BicSwift")] public BicSwift? BicSwift { get; set; }
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
        string id,
        InvoiceNumber invoiceNumber,
        SelectedLanguage selectedLanguage,
        SelectedLogo selectedLogo,
        DateOfInvoice dateOfInvoice,
        DateOfRelease dateOfRelease,
        DateOfPayment dateOfPayment,
        FormOfPayment formOfPayment,
        AccountPrefix accountPrefix,
        AccountNumber accountNumber,
        BicSwift? bicSwift,
        IsPaymentDivided isPaymentDivided,
        IsPaid isPaid,
        Remarks? remarks,
        Contractor seller,
        Contractor buyer,
        ICollection<ProductWithNumberOfUnits> products)
    {
        Id = id;
        InvoiceNumber = invoiceNumber;
        SelectedLanguage = selectedLanguage;
        SelectedLogo = selectedLogo;
        DateOfInvoice = dateOfInvoice;
        DateOfRelease = dateOfRelease;
        DateOfPayment = dateOfPayment;
        FormOfPayment = formOfPayment;
        AccountPrefix = accountPrefix;
        AccountNumber = accountNumber;
        BicSwift = bicSwift;
        IsPaymentDivided = isPaymentDivided;
        IsPaid = isPaid;
        Remarks = remarks;
        Seller = seller;
        Buyer = buyer;
        Products = products;
    }
}