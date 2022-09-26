using MediatR;
using Microsoft.EntityFrameworkCore;
using gp_Portal.Application.Common.Exceptions;
using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Domain.Entities;

namespace gp_Portal.Application.Linea.Commands.DeleteLineaBE;
public record DeleteLineaBECommand(int Id) : IRequest
{
    public bool Status { get; set; }
    //public bool Id { get; set; }

}

public class DeleteLineaBECommandHandler : IRequestHandler<DeleteLineaBECommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteLineaBECommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteLineaBECommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Lineas
        .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(LineaBE), request.Id);
        }

        entity.Status = request.Equals(0);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
