using MediatR;
using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Application.Common.Security;

namespace gp_Portal.Application.Linea.Commands.PurgeLineaBE;
[Authorize(Roles = "Administrator")]
[Authorize(Policy = "CanPurge")]
public record PurgeLineaBECommand : IRequest;

public class PurgeLineaBEListCommandHandler : IRequestHandler<PurgeLineaBECommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeLineaBEListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(PurgeLineaBECommand request, CancellationToken cancellationToken)
    {
        _context.Lineas.RemoveRange(_context.Lineas);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
