using MediatR;

namespace BluBlu.Invoices.Domain.Invoices.Commands.Update
{
    public class UpdateCommand : IRequest<Invoice>
    {
        public string Id { get; set; }
        public Invoice Invoice { get; set; }
    }
}