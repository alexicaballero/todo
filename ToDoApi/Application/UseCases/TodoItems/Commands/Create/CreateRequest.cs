using MediatR;
using System;
using TodoApi.Application.Dtos;

namespace ToDoApi.Application.UseCases.TodoItems.Commands.Create;

public record CreateRequest(Guid TodoListId, string Description) : IRequest<ToDoItemDto>
{
}