using gp_Portal.Application.Common.Mappings;
using gp_Portal.Domain.Entities;

namespace gp_Portal.Application.ServicioLinea.Queries.GetServiciosLineaWithPagination;
public class ServiciosLineaBriefDto : IMapFrom<ServiciosLineaBE>
{
    public int Id { get; init; }
    public int IdLinea { get; set; }
    public Timer? StartTime { get; set; }
    public Timer? EndTime { get; set; }
    public bool Status { get; set; }
    public bool IsBorrado { get; set; }
}
