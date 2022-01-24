using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.CreatePdf
{
    public class CreatePdfCommand : IRequest<Unit>
    {
        public Invoice Invoice { get; set; } = null!;
    }
}