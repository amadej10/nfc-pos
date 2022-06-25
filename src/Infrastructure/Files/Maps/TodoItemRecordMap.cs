using System.Globalization;
using nfc_pos.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace nfc_pos.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
