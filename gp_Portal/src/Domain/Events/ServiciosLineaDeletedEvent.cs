using gp_Portal.Domain.Entities;

namespace gp_Portal.Domain.Events;

public class ServiciosLineaDeletedEvent : BaseEvent
{
    public ServiciosLineaDeletedEvent(ServiciosLineaBE serviciosLinea)
    {
        ServiciosLinea = serviciosLinea;
    }

    public ServiciosLineaBE ServiciosLinea { get; }
}
