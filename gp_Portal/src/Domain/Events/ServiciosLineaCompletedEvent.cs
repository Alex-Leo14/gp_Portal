using gp_Portal.Domain.Entities;

namespace gp_Portal.Domain.Events;

public class ServiciosLineaCompletedEvent : BaseEvent
{
    public ServiciosLineaCompletedEvent(ServiciosLineaBE serviciosLinea)
    {
        ServiciosLinea = serviciosLinea;
    }

    public ServiciosLineaBE ServiciosLinea { get; }
}
