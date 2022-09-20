using AutoMapper;
using AutoMapper.QueryableExtensions;
using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Application.Common.Mappings;
using gp_Portal.Application.Common.Models;
using MediatR;

namespace gp_Portal.Application.ServicioLinea.Queries.GetServiciosLineaWithPagination;
public record GetServiciosLineaWithPaginationQuery : IRequest<PaginatedList<ServiciosLineaBriefDto>>
{
    public int IdLinea { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

}

public class GetServiciosLineaWithPaginationQueryHandler : IRequestHandler<GetServiciosLineaWithPaginationQuery, PaginatedList<ServiciosLineaBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetServiciosLineaWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ServiciosLineaBriefDto>> Handle(GetServiciosLineaWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.ServiciosLineas
            .Where(x => x.IdLinea == request.IdLinea)
            .OrderBy(x => x.StartTime)
            .ProjectTo<ServiciosLineaBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
