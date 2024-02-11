using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Application.Abstractions;
using TodoApi.Application.Dtos;
using TodoApi.Domain.Abstractios;

namespace ToDoApi.Application.UseCases.TodoItems.Commands.MarkAsDone;

public class MarkAsDoneRequestHandler : IRequestHandler<MarkAsDoneRequest, ToDoItemDto>
{
  private readonly IMapper mapper;
  private readonly IUnitOfWork unitOfWork;
  private readonly IToDoItemRepository toDoItemRepository;

  public MarkAsDoneRequestHandler(IMapper mapper, IUnitOfWork unitOfWork, IToDoItemRepository toDoItemRepository)
  {
    this.mapper = mapper;
    this.unitOfWork = unitOfWork;
    this.toDoItemRepository = toDoItemRepository;
  }

  public async Task<ToDoItemDto> Handle(MarkAsDoneRequest request, CancellationToken cancellationToken)
  {
    var toDoItem = await toDoItemRepository.GetByIdAsync(request.TodoItemId);
    if (toDoItem is null)
    {
      throw new DllNotFoundException(nameof(ToDoItemDto));
    }

    toDoItem.MarkComplete(request.isDone);

    var result = await toDoItemRepository.UpdateAsync(toDoItem);

    return mapper.Map<ToDoItemDto>(result);
  }
}