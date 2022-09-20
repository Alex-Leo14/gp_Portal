using gp_Portal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace gp_Portal.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<LineaBE> Lineas { get; }
    DbSet<ServiciosLineaBE> ServiciosLineas { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
