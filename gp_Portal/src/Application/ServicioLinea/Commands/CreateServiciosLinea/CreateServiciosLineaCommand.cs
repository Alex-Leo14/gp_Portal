using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Domain.Entities;
using gp_Portal.Domain.Events;
using MediatR;

namespace gp_Portal.Application.ServicioLinea.Commands.CreateServiciosLinea;
public record CreateServiciosLineaCommand : IRequest<int>
{
    public int LineaId { get; init; }

    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
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
        //var entity = new ServiciosLineaBE
        //{
        //    LineaId = request.LineaId,
        //    StartTime = request.StartTime,
        //    EndTime = request.EndTime,
        //    Status = request.Status,
        //    IsBorrado = false,
        //};

        //entity.AddDomainEvent(new ServiciosLineaCreatedEvent(entity));

        //_context.ServiciosLineas.Add(entity);

        //await _context.SaveChangesAsync(cancellationToken);

        //return entity.Id;

        var entity = new ServiciosLineaBE();

        entity.LineaId = request.LineaId;
        entity.StartTime = request.StartTime;
        entity.EndTime = request.EndTime;
        entity.Status = request.Status;
        entity.IsBorrado = request.Equals(0);

        _context.ServiciosLineas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;

    }
}
