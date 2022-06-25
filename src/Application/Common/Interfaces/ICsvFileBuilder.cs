using nfc_pos.Application.TodoLists.Queries.ExportTodos;

namespace nfc_pos.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
