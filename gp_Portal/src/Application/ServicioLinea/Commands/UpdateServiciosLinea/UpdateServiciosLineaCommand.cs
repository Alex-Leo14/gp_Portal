using gp_Portal.Application.Common.Exceptions;
using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Domain.Entities;
using MediatR;

namespace gp_Portal.Application.ServicioLinea.Commands.UpdateServiciosLinea;
public record UpdateServiciosLineaCommand : IRequest
{
    public int Id { get; init; }
    public int LineaId { get; init; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public bool Status { get; set; }
    public bool IsBorrado { get; set; }
}

public class UpdateServiciosLineaCommandHandler : IRequestHandler<UpdateServiciosLineaCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateServiciosLineaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateServiciosLineaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ServiciosLineas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ServiciosLineaBE), request.Id);
        }

        entity.StartTime = request.StartTime;
        entity.EndTime = request.EndTime;
        entity.Status = request.Status;
        entity.LineaId = request.LineaId;
        entity.IsBorrado = request.IsBorrado;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
