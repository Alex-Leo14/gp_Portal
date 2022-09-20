using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Domain.Entities;
using gp_Portal.Domain.Events;
using MediatR;

namespace gp_Portal.Application.ServicioLinea.Commands.CreateServiciosLinea;
public record CreateServiciosLineaCommand : IRequest<int>
{
    public int IdLinea { get; init; }

    public Timer? StartTime { get; set; }
    public Timer? EndTime { get; set; }
    public bool Status { get; set; }
    public bool IsBorrado { get; set; }
}

public class CreateServiciosLineaCommandHandler : IRequestHandler<CreateServiciosLineaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateServiciosLineaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateServiciosLineaCommand request, CancellationToken cancellationToken)
    {
        var entity = new ServiciosLineaBE
        {
            IdLinea = request.IdLinea,
            //IdLinea = request.IdLinea,
        };

        entity.AddDomainEvent(new ServiciosLineaCreatedEvent(entity));

        _context.ServiciosLineas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
