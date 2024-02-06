using MediatR;
using System;
using TodoApi.Application.Dtos;

namespace ToDoApi.Application.UseCases.TodoLists.Queries.GetById;

public record GetByIdRequest(Guid Id) : IRequest<ToDoListDto>
{
}