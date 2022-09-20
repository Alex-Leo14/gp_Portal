using gp_Portal.Application.Common.Mappings;
using gp_Portal.Application.TodoLists.Queries.GetTodos;
using gp_Portal.Domain.Entities;

namespace gp_Portal.Application.Linea.Queries.GetLineaBE;
public class LineaDto : IMapFrom<LineaBE>
{
    public LineaDto()
    {
        ListServicio = new List<ServiciosLineaDto>();
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Route { get; set; }
    public int Direction { get; set; }
    public bool Status { get; set; }
    public IList<ServiciosLineaDto> ListServicio { get; set; }

}
