using System.Globalization;
using CsvHelper.Configuration;
using gp_Portal.Application.TodoLists.Queries.ExportTodos;

namespace gp_Portal.Infrastructure.Files.Maps;
public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
