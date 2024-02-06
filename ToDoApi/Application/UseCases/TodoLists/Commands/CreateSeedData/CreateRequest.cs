using MediatR;

namespace ToDoApi.Application.UseCases.TodoLists.Commands.CreateSeedData;

public record CreateSeedDataRequest() : IRequest<Unit>
{ }