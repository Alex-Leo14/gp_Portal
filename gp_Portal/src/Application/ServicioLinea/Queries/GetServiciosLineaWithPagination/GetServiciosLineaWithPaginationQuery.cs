using AutoMapper;
using AutoMapper.QueryableExtensions;
using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Application.Common.Mappings;
using gp_Portal.Application.Common.Models;
using MediatR;

namespace gp_Portal.Application.ServicioLinea.Queries.GetServiciosLineaWithPagination;
public record GetServiciosLineaWithPaginationQuery : IRequest<PaginatedList<ServiciosLineaDto>>
{
    public int LineaId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

}

public class GetServiciosLineaWithPaginationQueryHandler : IRequestHandler<GetServiciosLineaWithPaginationQuery, PaginatedList<ServiciosLineaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetServiciosLineaWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ServiciosLineaDto>> Handle(GetServiciosLineaWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.ServiciosLineas
            .Where(x => x.LineaId == request.LineaId)
            .OrderBy(x => x.StartTime)
            .ProjectTo<ServiciosLineaDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
