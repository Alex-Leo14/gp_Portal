using gp_Portal.Application.Linea.Queries.GetLineaBE;
using gp_Portal.Application.TodoLists.Queries.GetTodos;

namespace gp_Portal.Application.Linea.Queries.GetLineaBE;

public class LineaVm
{
    public IList<PriorityLineaDto> PriorityLineaDto { get; set; } = new List<PriorityLineaDto>();
    public IList<LineaDto> Lists { get; set; } = new List<LineaDto>();
}
