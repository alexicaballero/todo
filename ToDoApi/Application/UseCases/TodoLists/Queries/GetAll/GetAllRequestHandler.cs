using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Application.Abstractions;
using TodoApi.Application.Dtos;
using TodoApi.Domain.Abstractios;

namespace ToDoApi.Application.UseCases.TodoLists.Queries.GetAll;

public class GetAllRequestHandler : IRequestHandler<GetAllRequest, IEnumerable<ToDoListDto>>
{
  private readonly IMapper mapper;
  private readonly IUnitOfWork unitOfWork;
  private readonly IToDoListRepository toDoListRepository;

  public GetAllRequestHandler(IMapper mapper, IUnitOfWork unitOfWork, IToDoListRepository toDoListRepository)
  {
    this.mapper = mapper;
    this.unitOfWork = unitOfWork;
    this.toDoListRepository = toDoListRepository;
  }

  public async Task<IEnumerable<ToDoListDto>> Handle(GetAllRequest request, CancellationToken cancellationToken)
  {
    var toDoList = await toDoListRepository.GetAllAsync();

    return mapper.Map<List<ToDoListDto>>(toDoList);
  }
}