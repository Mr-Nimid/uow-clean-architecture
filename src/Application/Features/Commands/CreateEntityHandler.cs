using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands;

public class CreateEntityHandler : IRequestHandler<CreateEntityCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEntityHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
    {
        var entity = new YourEntity { Name = request.Name };
        await _unitOfWork.Repository<YourEntity, int>().AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return entity.Id;
    }
}