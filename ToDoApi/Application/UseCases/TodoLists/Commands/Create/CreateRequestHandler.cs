using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Application.Abstractions;
using TodoApi.Application.Dtos;
using TodoApi.Domain.Abstractios;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Exceptions;

namespace ToDoApi.Application.UseCases.TodoLists.Commands.Create;

public class CreateRequestHandler : IRequestHandler<CreateRequest, ToDoListDto>
{
  private readonly IMapper mapper;
  private readonly IUnitOfWork unitOfWork;
  private readonly IToDoListRepository toDoListRepository;

  public CreateRequestHandler(IMapper mapper, IUnitOfWork unitOfWork, IToDoListRepository toDoListRepository)
  {
    this.mapper = mapper;
    this.unitOfWork = unitOfWork;
    this.toDoListRepository = toDoListRepository;
  }

  public async Task<ToDoListDto> Handle(CreateRequest request, CancellationToken cancellationToken)
  {
    var toDoListEntity = ToDoList.Create(request.title);
    var toDoList = await toDoListRepository.AddAsync(toDoListEntity);
    var recordsAffected = await unitOfWork.SaveChangesAsync(cancellationToken);

    if (recordsAffected < 1)
    {
      throw new CreateException(nameof(ToDoItem));
    }

    return mapper.Map<ToDoListDto>(toDoList);
  }
}