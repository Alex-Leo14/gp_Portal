using gp_Portal.Application.Common.Interfaces;

namespace gp_Portal.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
