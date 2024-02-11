using MediatR;
using System;
using TodoApi.Application.Dtos;

namespace ToDoApi.Application.UseCases.TodoItems.Commands.MarkAsDone;

public record MarkAsDoneRequest(Guid TodoItemId, bool isDone) : IRequest<ToDoItemDto>
{
}