using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using gp_Portal.Application.Common.Interfaces;

namespace gp_Portal.Application.Linea.Queries.GetLineaBE;

public record GetLineaBEQuery : IRequest<LineaVm>;

public class GetLineaQueryHandler : IRequestHandler<GetLineaBEQuery, LineaVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLineaQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<LineaVm> Handle(GetLineaBEQuery request, CancellationToken cancellationToken)
    {
        return new LineaVm
        {

            Lists = await _context.Lineas
                .AsNoTracking()
                .Where(t=>t.Status.Equals(true))
                .ProjectTo<LineaDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
        };
    }
}
