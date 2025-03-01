using MediatR;

namespace Application.Features.Commands;

public record CreateEntityCommand(string Name) : IRequest<int>;