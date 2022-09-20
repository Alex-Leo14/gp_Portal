using gp_Portal.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace gp_Portal.Application.ServicioLinea.EventHandlers;
public class ServiciosLineaCompletedEventHandler : INotificationHandler<ServiciosLineaCompletedEvent>
{
    private readonly ILogger<ServiciosLineaCompletedEventHandler> _logger;

    public ServiciosLineaCompletedEventHandler(ILogger<ServiciosLineaCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ServiciosLineaCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("gp_Portal Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
