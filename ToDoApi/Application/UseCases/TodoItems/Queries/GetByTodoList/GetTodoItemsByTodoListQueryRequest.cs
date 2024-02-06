using MediatR;
using System;
using System.Collections.Generic;
using TodoApi.Application.Dtos;

namespace ToDoApi.Application.UseCases.TodoItems.Queries.GetByTodoList;

public record GetByTodoListRequest(Guid TodoListId) : IRequest<IEnumerable<ToDoItemDto>>
{
}