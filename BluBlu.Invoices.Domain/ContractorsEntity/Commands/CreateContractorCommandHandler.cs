using MediatR;

namespace BluBlu.Invoices.Domain.ContractorsEntity.Commands;

public class CreateContractorCommandHandler : IRequestHandler<CreateContractorCommand, Contractor>
{
    private readonly IContractorsRepository _contractorsRepository;

    public CreateContractorCommandHandler(IContractorsRepository contractorsRepository)
    {
        _contractorsRepository = contractorsRepository;
    }

    public async Task<Contractor> Handle(CreateContractorCommand request, CancellationToken cancellationToken)
    {
        return await _contractorsRepository.CreateContractor(request.Contractor);
    }
}