using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Application.Abstractions;
using TodoApi.Application.Dtos;

namespace ToDoApi.Application.UseCases.TodoItems.Queries.GetByTodoList;

public class GetByTodoListRequestHandler : IRequestHandler<GetByTodoListRequest, IEnumerable<ToDoItemDto>>
{
  private readonly IMapper mapper;
  private readonly IToDoItemRepository toDoItemRepository;

  public GetByTodoListRequestHandler(IMapper mapper, IToDoItemRepository toDoItemRepository)
  {
    this.mapper = mapper;
    this.toDoItemRepository = toDoItemRepository;
  }

  public async Task<IEnumerable<ToDoItemDto>> Handle(GetByTodoListRequest request, CancellationToken cancellationToken)
  {
    var toDoItems = await toDoItemRepository.GetAllByTodoListIdAsync(request.TodoListId);

    return mapper.Map<IEnumerable<ToDoItemDto>>(toDoItems);
  }
}