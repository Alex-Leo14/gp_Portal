using gp_Portal.Application.TodoLists.Queries.ExportTodos;

namespace gp_Portal.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
