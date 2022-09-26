using gp_Portal.Application.Common.Exceptions;
using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Domain.Entities;
using gp_Portal.Domain.Events;
using MediatR;

namespace gp_Portal.Application.ServicioLinea.Commands.DeleteServiciosLinea;
public record DeleteServiciosLineaCommand(int Id) : IRequest
{
    public bool Status { get; set; }

};


public class DeleteServiciosLineaCommandHandler : IRequestHandler<DeleteServiciosLineaCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteServiciosLineaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteServiciosLineaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ServiciosLineas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ServiciosLineaBE), request.Id);
        }

        entity.Status = request.Equals(0);


        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
