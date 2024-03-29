﻿using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

namespace BluBlu.Blazor.Pages.Invoices.Requests;

public class InvoiceRequestModel
{
    public string Id { get; set; } = null!;
    public string InvoiceNumber { get; set; } = null!;
    public string Currency { get; set; } = null!;
    public string SelectedLanguage { get; set; } = null!;
    public string SelectedLogo { get; set; } = null!;
    public DateTime DateOfInvoice { get; set; }
    public DateTime DateOfRelease { get; set; }
    public DateTime DateOfPayment { get; set; }
    public string FormOfPayment { get; set; } = null!;
    public string AccountPrefix { get; set; } = null!;
    public string AccountNumber { get; set; } = null!;
    public string BicSwift { get; set; } = null!;
    public bool IsPaymentDivided { get; set; }
    public bool IsPaid { get; set; }
    public string Remarks { get; set; } = null!;
    public TenantRequestModel Seller { get; set; } = null!;
    public TenantRequestModel Buyer { get; set; } = null!;
    public ICollection<ProductRequestModel> Products { get; set; } = null!;
    
    public BluBlu.Invoices.Domain.InvoicesAggregate.Invoice ToDomainModel()
    {
        return new(
            Id,
            new(InvoiceNumber),
            new(Currency),
            new(SelectedLanguage),
            new(SelectedLogo),
            new(DateOfInvoice),
            new(DateOfRelease),
            new(DateOfPayment),
            new(FormOfPayment),
            string.IsNullOrWhiteSpace(AccountPrefix) ? null : new(AccountPrefix),
            new(AccountNumber),
            string.IsNullOrWhiteSpace(BicSwift) ? null : new(BicSwift),
            new(IsPaymentDivided),
            new(IsPaid),
            string.IsNullOrWhiteSpace(Remarks) ? null : new(Remarks),
            new(
                new(Seller.Name),
                new(
                    new(Seller.AddressStreet),
                    new(Seller.AddressPostCity),
                    new(Seller.AddressCountry),
                    new(Seller.AddressPostCode),
                    new(Seller.AddressBuildingNumber),
                    string.IsNullOrWhiteSpace(Seller.AddressFlatNumber) ? null : new(Seller.AddressFlatNumber)),
                string.IsNullOrWhiteSpace(Seller.Nip) ? null : new(Seller.Nip),
                string.IsNullOrWhiteSpace(Seller.NipPrefix) ? null : new(Seller.NipPrefix)),
            new(
                new(Buyer.Name),
                new(
                    new(Buyer.AddressStreet),
                    new(Buyer.AddressPostCity),
                    new(Buyer.AddressCountry),
                    new(Buyer.AddressPostCode),
                    new(Buyer.AddressBuildingNumber),
                    string.IsNullOrWhiteSpace(Buyer.AddressFlatNumber) ? null : new(Buyer.AddressFlatNumber)),
                string.IsNullOrWhiteSpace(Buyer.Nip) ? null : new(Buyer.Nip),
                string.IsNullOrWhiteSpace(Buyer.NipPrefix) ? null : new(Buyer.NipPrefix)),
            Products.Select(product => new ProductWithNumberOfUnits(
                    new(
                        new(product.Name),
                        new(product.PriceNet),
                        new(product.UnitName),
                        new(product.Vat),
                        new(product.IsVatZw),
                        new(product.PriceGross),
                        string.IsNullOrWhiteSpace(product.LegalBasisForTaxExemption) ? null : new(product.LegalBasisForTaxExemption)), 
                    new(product.NumberOfUnits)))
                .ToList());
    }
}