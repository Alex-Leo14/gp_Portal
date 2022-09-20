using gp_Portal.Application.Common.Mappings;
using gp_Portal.Domain.Entities;

namespace gp_Portal.Application.Common.Models;
// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
