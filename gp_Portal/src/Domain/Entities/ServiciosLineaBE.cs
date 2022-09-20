using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gp_Portal.Domain.Entities;
public class ServiciosLineaBE : BaseAuditableEntity
{

    //public int IdServicio { get; set; }
    public int LineaId { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public bool Status { get; set; }
    public bool IsBorrado { get; set; }


    public LineaBE Linea { get; set; } = null!;


}
