using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Application.Abstractions;
using TodoApi.Application.Dtos;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Exceptions;

namespace ToDoApi.Application.UseCases.TodoLists.Queries.GetById;

public class GetByIdRequestHandler : IRequestHandler<GetByIdRequest, ToDoListDto>
{
  private readonly IMapper mapper;
  private readonly IToDoListRepository toDoListRepository;

  public GetByIdRequestHandler(IMapper mapper, IToDoListRepository toDoListRepository)
  {
    this.mapper = mapper;
    this.toDoListRepository = toDoListRepository;
  }

  public async Task<ToDoListDto> Handle(GetByIdRequest request, CancellationToken cancellationToken)
  {
    var toDoList = await toDoListRepository.GetByIdAsync(request.Id);
    if (toDoList is null)
    {
      throw new NotFoundException(nameof(ToDoList), request.Id);
    }

    return mapper.Map<ToDoListDto>(toDoList);
  }
}