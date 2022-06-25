using nfc_pos.Application.Common.Mappings;
using nfc_pos.Domain.Entities;

namespace nfc_pos.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
