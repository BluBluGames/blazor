using MediatR;

namespace BluBlu.Invoices.Domain.Invoices.Commands.CreatePdf
{
    public class CreatePdfCommand : IRequest<Unit>
    {
        public Invoice Invoice { get; set; }
    }
}