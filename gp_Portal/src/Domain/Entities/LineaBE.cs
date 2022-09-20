using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gp_Portal.Domain.Entities;
public class LineaBE : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Route { get; set; }
    public int Direction { get; set; }
    public bool Status { get; set; }
    public IList<ServiciosLineaBE> Servicios { get; private set; } = new List<ServiciosLineaBE>();


}
