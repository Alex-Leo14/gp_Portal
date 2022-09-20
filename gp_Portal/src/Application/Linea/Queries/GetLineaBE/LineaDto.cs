using gp_Portal.Application.Common.Mappings;
using gp_Portal.Domain.Entities;

namespace gp_Portal.Application.Linea.Queries.GetLineaBE;
public class LineaDto : IMapFrom<LineaBE>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Route { get; set; }
    public int Direction { get; set; }
    public bool Status { get; set; }
}
