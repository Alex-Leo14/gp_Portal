using MediatR;
using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Domain.Entities;

namespace gp_Portal.Application.Linea.Commands.CreateLineaBE;
public record CreateLineaBECommand : IRequest<int>
{
    public string? Name { get; set; }
    public string? Route { get; set; }
    public int Direction { get; set; }
    public bool Status { get; set; }
}

public class CreateLineaBECommandHandler : IRequestHandler<CreateLineaBECommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateLineaBECommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateLineaBECommand request, CancellationToken cancellationToken)
    {
        var entity = new LineaBE();

        entity.Name = request.Name;
        entity.Route = request.Route;
        entity.Direction = request.Direction;
        entity.Status = request.Status;

        _context.Lineas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
