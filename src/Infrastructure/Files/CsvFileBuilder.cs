using System.Globalization;
using nfc_pos.Application.Common.Interfaces;
using nfc_pos.Application.TodoLists.Queries.ExportTodos;
using nfc_pos.Infrastructure.Files.Maps;
using CsvHelper;

namespace nfc_pos.Infrastructure.Files;

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
