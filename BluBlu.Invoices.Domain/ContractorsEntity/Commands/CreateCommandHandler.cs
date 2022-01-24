using MediatR;

namespace BluBlu.Invoices.Domain.ContractorsEntity.Commands;

public class CreateCommandHandler : IRequestHandler<CreateCommand, Contractor>
{
    private readonly IContractorsRepository _contractorsRepository;

    public CreateCommandHandler(IContractorsRepository contractorsRepository)
    {
        _contractorsRepository = contractorsRepository;
    }

    public async Task<Contractor> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        return await _contractorsRepository.Create(request.Contractor);
    }
}