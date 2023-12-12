using MediatR;

namespace BluBlu.Invoices.Domain.ContractorsEntity.Commands;

public class CreateContractorCommandHandler : IRequestHandler<CreateContractorCommand, Contractor>
{
    private readonly IContractorsRepositoryMongo _contractorsRepository;

    public CreateContractorCommandHandler(IContractorsRepositoryMongo contractorsRepository)
    {
        _contractorsRepository = contractorsRepository;
    }

    public async Task<Contractor> Handle(CreateContractorCommand request, CancellationToken cancellationToken)
    {
        return await _contractorsRepository.CreateContractor(request.Contractor);
    }
}