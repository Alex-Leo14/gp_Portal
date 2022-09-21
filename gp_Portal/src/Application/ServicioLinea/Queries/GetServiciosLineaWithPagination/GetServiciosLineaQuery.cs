using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Application.Common.Security;
using gp_Portal.Domain.Enums;
using gp_Portal.Application.Common.Exceptions;
using gp_Portal.Domain.Entities;
using gp_Portal.Domain.Events;

namespace gp_Portal.Application.ServicioLinea.Queries.GetServiciosLineaWithPagination;

public record GetServiciosLineaQuery(int LineaId) : IRequest<ServiciosLineaVm>;

public class GetServiciosLineaQueryHandler : IRequestHandler<GetServiciosLineaQuery, ServiciosLineaVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetServiciosLineaQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<ServiciosLineaVm> Handle(GetServiciosLineaQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.ServiciosLineas
        .FindAsync(new object[] { request.LineaId }, cancellationToken);
        int ID = request.LineaId;

        if (ID == 0)
        {
            throw new NotFoundException(nameof(ServiciosLineaBE), request.LineaId);
        }

        else
        {
            return new ServiciosLineaVm
            {

             Lists = await _context.ServiciosLineas
            .Where(x => x.LineaId == request.LineaId)
            .OrderBy(t => t.StartTime)
            .ProjectTo<ServiciosLineaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken)
            };


        }




    }
}
