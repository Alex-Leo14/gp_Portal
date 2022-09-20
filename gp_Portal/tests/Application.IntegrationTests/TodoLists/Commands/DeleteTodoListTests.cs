using FluentAssertions;
using gp_Portal.Application.Common.Exceptions;
using gp_Portal.Application.TodoLists.Commands.CreateTodoList;
using gp_Portal.Application.TodoLists.Commands.DeleteTodoList;
using gp_Portal.Domain.Entities;
using NUnit.Framework;

using static gp_Portal.Application.IntegrationTests.Testing;

namespace gp_Portal.Application.IntegrationTests.TodoLists.Commands;
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
