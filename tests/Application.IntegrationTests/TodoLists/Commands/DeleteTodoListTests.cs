using nfc_pos.Application.Common.Exceptions;
using nfc_pos.Application.TodoLists.Commands.CreateTodoList;
using nfc_pos.Application.TodoLists.Commands.DeleteTodoList;
using nfc_pos.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace nfc_pos.Application.IntegrationTests.TodoLists.Commands;

using static Testing;

public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
