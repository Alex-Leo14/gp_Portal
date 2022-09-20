using gp_Portal.Application.Linea.Queries.GetLineaBE;

namespace gp_Portal.Application.Linea.Queries.GetLineaBE;

public class LineaVm
{
    public IList<LineaDto> Lists { get; set; } = new List<LineaDto>();
}
