using MediatR;
using System;

namespace ToDoApi.Application.UseCases.TodoItems.Commands.Delete;

public record DeleteRequest(Guid Id) : IRequest<Unit>
{
}