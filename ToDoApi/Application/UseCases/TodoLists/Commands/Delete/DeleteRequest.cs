using MediatR;
using System;

namespace ToDoApi.Application.UseCases.TodoLists.Commands.Delete;

public record DeleteRequest(Guid Id) : IRequest<Unit>
{
}