using AutoMapper;
using gp_Portal.Application.Common.Mappings;
using gp_Portal.Domain.Entities;

namespace gp_Portal.Application.Linea.Queries.GetLineaBE;
public class ServiciosLineaDto : IMapFrom<TodoItem>
{
    public int Id { get; init; }
    public int IdLinea { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public bool Status { get; set; }
    public bool IsBorrado { get; set; }
}
