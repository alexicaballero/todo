using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Application.Abstractions;
using TodoApi.Domain.Abstractios;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Exceptions;

namespace ToDoApi.Application.UseCases.TodoLists.Commands.Delete;

public class DeleteRequestHandler : IRequestHandler<DeleteRequest, Unit>
{
  private readonly IUnitOfWork unitOfWork;
  private readonly IToDoListRepository toDoListRepository;

  public DeleteRequestHandler(IUnitOfWork unitOfWork, IToDoListRepository toDoListRepository)
  {
    this.unitOfWork = unitOfWork;
    this.toDoListRepository = toDoListRepository;
  }

  public async Task<Unit> Handle(DeleteRequest request, CancellationToken cancellationToken)
  {
    var toDoList = await toDoListRepository.GetByIdAsync(request.Id);
    if (toDoList == null)
    {
      throw new NotFoundException(nameof(TodoLists), request.Id);
    }

    await toDoListRepository.DeleteAsync(toDoList);

    var recordsAfected = await unitOfWork.SaveChangesAsync(cancellationToken);
    if (recordsAfected < 1)
    {
      throw new DeleteException(nameof(ToDoItem));
    }

    return Unit.Value;
  }
}