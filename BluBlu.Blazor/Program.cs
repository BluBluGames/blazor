using BluBlu.Auth.Domain.User;
using BluBlu.Auth.Infrastructure.Database.Contexts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BluBlu.Blazor.Areas.Identity;
using BluBlu.Invoices.Domain;
using BluBlu.Invoices.Domain.ContractorsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate;
using BluBlu.Invoices.Infrastructure.Connection;
using BluBlu.Invoices.Infrastructure.Contractors;
using BluBlu.Invoices.Infrastructure.Invoices;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AuthDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// AUTH
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<BluBluIdentity>>();
builder.Services.AddDefaultIdentity<BluBluIdentity>(options => options.SignIn.RequireConfirmedAccount = true) //Define User Class
    .AddRoles<IdentityRole>() //Allows defining user roles
    .AddEntityFrameworkStores<AuthDbContext>(); //Without this cant make first migration to in Auth.Infrastucture
// --AUTH

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMediatR(typeof(InvoicesDomainEmptyClass));
builder.Services.Configure<InvoicesOptions>(builder.Configuration.GetSection("MongoClient"));
builder.Services.AddSingleton<IInvoicesDatabase, InvoicesDatabase>();
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddTransient<IContractorsRepository, ContractorsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();