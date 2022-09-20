using MediatR;
using gp_Portal.Application.Common.Exceptions;
using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Domain.Entities;

namespace gp_Portal.Application.Linea.Commands.UpdateLineaBE;
public record UpdateLineaBECommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; set; }
    public string? Route { get; set; }
    public int Direction { get; set; }
    public bool Status { get; set; }
}

public class UpdateLineaBECommandHandler : IRequestHandler<UpdateLineaBECommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateLineaBECommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateLineaBECommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Lineas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(LineaBE), request.Id);
        }

        entity.Name = request.Name;
        entity.Route = request.Route;
        entity.Direction = request.Direction;
        entity.Status = request.Status;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
