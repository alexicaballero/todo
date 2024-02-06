using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Application.Abstractions;
using TodoApi.Application.Dtos;
using TodoApi.Domain.Abstractios;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Exceptions;

namespace ToDoApi.Application.UseCases.TodoItems.Commands.Create;

public class CreateRequestHandler : IRequestHandler<CreateRequest, ToDoItemDto>
{
  private readonly IMapper mapper;
  private readonly IUnitOfWork unitOfWork;
  private readonly IToDoItemRepository toDoItemRepository;

  public CreateRequestHandler(IMapper mapper, IUnitOfWork unitOfWork, IToDoItemRepository toDoItemRepository)
  {
    this.mapper = mapper;
    this.unitOfWork = unitOfWork;
    this.toDoItemRepository = toDoItemRepository;
  }

  public async Task<ToDoItemDto> Handle(CreateRequest request, CancellationToken cancellationToken)
  {
    var toDoItem = ToDoItem.Create(request.TodoListId, request.Description);
    var toDoItemResult = await toDoItemRepository.AddAsync(toDoItem);
    var recordsAffected = await unitOfWork.SaveChangesAsync(cancellationToken);

    if (recordsAffected < 1)
    {
      throw new CreateException(nameof(ToDoItem));
    }

    return mapper.Map<ToDoItemDto>(toDoItemResult);
  }
}