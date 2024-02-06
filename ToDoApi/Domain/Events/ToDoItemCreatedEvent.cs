using TodoApi.Domain.Abstractios;
using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Events;

public record ToDoItemCreatedEvent(ToDoItem TodoItem) : DomainEvent
{
}