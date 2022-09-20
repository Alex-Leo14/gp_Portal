using gp_Portal.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace gp_Portal.Application.ServicioLinea.EventHandlers;
public class ServiciosLineaCreatedEventHandler : INotificationHandler<ServiciosLineaCreatedEvent>
{
    private readonly ILogger<ServiciosLineaCreatedEventHandler> _logger;

    public ServiciosLineaCreatedEventHandler(ILogger<ServiciosLineaCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ServiciosLineaCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("gp_Portal Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
