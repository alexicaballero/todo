using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Application.Abstractions;
using TodoApi.Domain.Abstractios;
using TodoApi.Domain.Entities;

namespace ToDoApi.Application.UseCases.TodoLists.Commands.CreateSeedData;

public class CreateSeedDataRequestHandler : IRequestHandler<CreateSeedDataRequest, Unit>
{
  private readonly IUnitOfWork unitOfWork;
  private readonly IToDoListRepository toDoListRepository;

  public CreateSeedDataRequestHandler(IUnitOfWork unitOfWork, IToDoListRepository toDoListRepository)
  {
    this.unitOfWork = unitOfWork;
    this.toDoListRepository = toDoListRepository;
  }

  public async Task<Unit> Handle(CreateSeedDataRequest request, CancellationToken cancellationToken)
  {
    for (var i = 0; i < 5; i++)
    {
      var toDoList = ToDoList.Create($"List #id");
      if (toDoList is null)
        continue;

      toDoList.Title = toDoList!.Title.Replace("#id", toDoList?.Id.ToString());

      for (var k = 0; k < 5; k++)
      {
        var toDoItem = toDoList.AddItem($"Task #id");
        toDoItem.Description = toDoItem.Description.Replace("#id", toDoItem?.Id.ToString());
      }

      await toDoListRepository.AddAsync(toDoList);
      await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    return Unit.Value;
  }
}