using gp_Portal.Application.Common.Mappings;
using gp_Portal.Domain.Entities;

namespace gp_Portal.Application.ServicioLinea.Queries.GetServiciosLineaWithPagination;
public class ServiciosLineaDto : IMapFrom<ServiciosLineaBE>
{
    public int Id { get; init; }
    public int LineaId { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public bool Status { get; set; }
    public bool IsBorrado { get; set; }
}
