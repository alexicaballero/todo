using MediatR;
using TodoApi.Application.Dtos;

namespace ToDoApi.Application.UseCases.TodoLists.Commands.Create;

public record CreateRequest(string title) : IRequest<ToDoListDto>
{ }