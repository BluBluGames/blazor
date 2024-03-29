using MediatR;
using Microsoft.AspNetCore.Components;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.CreatePdf
{
    public class CreatePdfCommand : IRequest<Unit>
    {
        public Invoice Invoice { get; set; } = null!;
        public NavigationManager NavigationManager { get; set; } = null!;
    }
}