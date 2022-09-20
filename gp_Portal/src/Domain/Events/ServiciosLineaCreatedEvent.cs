namespace gp_Portal.Domain.Events;

public class ServiciosLineaCreatedEvent : BaseEvent
{
    public ServiciosLineaCreatedEvent(ServiciosLineaBE serviciosLinea)
    {
        ServiciosLinea = serviciosLinea;
    }

    public ServiciosLineaBE ServiciosLinea { get; }
}
