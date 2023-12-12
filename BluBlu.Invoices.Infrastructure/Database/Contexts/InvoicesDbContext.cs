using BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects;
using BluBlu.Invoices.Domain.ContractorsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate;
using Microsoft.EntityFrameworkCore;

namespace BluBlu.Invoices.Infrastructure.Database.Contexts;

public class InvoicesDbContext : DbContext
{
    public InvoicesDbContext(DbContextOptions<InvoicesDbContext> options) : base(options) { }
    
    //public DbSet<Tenant> Tenants { get; set; }
    //public DbSet<User> Users { get; set; }
    //public DbSet<Invoice> Invoices { get; set; }
    //public DbSet<Contractor> Contractors { get; set; }
    //public DbSet<Address> Addresses { get; set; }
    //public DbSet<Product> Products { get; set; }
    //public DbSet<ProductInvoice> ProductInvoices { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Defining the User to Tenant relationship
        //builder.Entity<User>()
        //    .HasOne(u => u.Tenant)
        //    .WithMany(t => t.Users)
        //    .HasForeignKey(u => u.TenantId);

        //// Defining the Invoice to User relationship
        //builder.Entity<Invoice>()
        //    .HasOne(i => i.User)
        //    .WithMany(u => u.Invoices)
        //    .HasForeignKey(i => i.UserId);

        //// Defining the Contractor to Address relationship
        //builder.Entity<Contractor>()
        //    .HasOne(c => c.Address)
        //    .WithOne(a => a.Contractor)
        //    .HasForeignKey<Address>(a => a.ContractorId);

        //// Defining the many-to-many relationship between Product and Invoice
        //builder.Entity<ProductInvoice>()
        //    .HasKey(pi => new { pi.ProductId, pi.InvoiceId });

        //builder.Entity<ProductInvoice>()
        //    .HasOne(pi => pi.Product)
        //    .WithMany(p => p.ProductInvoices)
        //    .HasForeignKey(pi => pi.ProductId);

        //builder.Entity<ProductInvoice>()
        //    .HasOne(pi => pi.Invoice)
        //    .WithMany(i => i.ProductInvoices)
        //    .HasForeignKey(pi => pi.InvoiceId);
    }
}
