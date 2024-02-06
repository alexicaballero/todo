using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Application.Abstractions;
using TodoApi.Domain.Abstractios;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Exceptions;

namespace ToDoApi.Application.UseCases.TodoItems.Commands.Delete;

public class DeleteRequestHandler : IRequestHandler<DeleteRequest, Unit>
{
  private readonly IUnitOfWork unitOfWork;
  private readonly IToDoItemRepository toDoItemRepository;

  public DeleteRequestHandler(IUnitOfWork unitOfWork, IToDoItemRepository toDoItemRepository)
  {
    this.unitOfWork = unitOfWork;
    this.toDoItemRepository = toDoItemRepository;
  }

  public async Task<Unit> Handle(DeleteRequest request, CancellationToken cancellationToken)
  {
    var toDoItem = await toDoItemRepository.GetByIdAsync(request.Id);
    if (toDoItem == null)
    {
      throw new NotFoundException(nameof(toDoItem), request.Id);
    }

    await toDoItemRepository.DeleteAsync(toDoItem);

    var recordsAfected = await unitOfWork.SaveChangesAsync(cancellationToken);
    if (recordsAfected < 1)
    {
      throw new DeleteException(nameof(ToDoItem));
    }

    return Unit.Value;
  }
}