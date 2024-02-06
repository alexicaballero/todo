using TodoApi.Domain.Abstractios;
using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Events;

public record ToDoItemCompletedEvent(ToDoItem TodoItem) : DomainEvent
{
}