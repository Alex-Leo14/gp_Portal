using System.Globalization;
using CsvHelper;
using gp_Portal.Application.Common.Interfaces;
using gp_Portal.Application.TodoLists.Queries.ExportTodos;
using gp_Portal.Infrastructure.Files.Maps;

namespace gp_Portal.Infrastructure.Files;
public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
