using MediatR;
using Microsoft.EntityFrameworkCore;
using gp_Portal.Application.Common.Exceptions;
using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Domain.Entities;
using gp_Portal.Application.Linea.Commands.UpdateLineaBE;

namespace gp_Portal.Application.Linea.Commands.DeleteLineaBE;
public record DeleteLineaBELogic : IRequest
{
    public int Id { get; init; }
    public string? Name { get; set; }
    public string? Route { get; set; }
    public int Direction { get; set; }
    public bool Status { get; set; }
}

public class DeleteLineaBELogicHandler : IRequestHandler<DeleteLineaBELogic>
{
    private readonly IApplicationDbContext _context;

    public DeleteLineaBELogicHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteLineaBELogic request, CancellationToken cancellationToken)
    {
        var entity = await _context.Lineas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(LineaBE), request.Id);
        }

        
        entity.Status = request.Status.Equals(false);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
