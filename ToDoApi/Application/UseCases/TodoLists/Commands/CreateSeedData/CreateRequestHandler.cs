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
      var toDoList = ToDoList.Create($"To Do List {i.ToString("000")}");
      if (toDoList is null)
        continue;


      for (var k = 0; k < 5; k++)
      {
        toDoList.AddItem($"Task Item {k.ToString("000")}");
      }

      await toDoListRepository.AddAsync(toDoList);
      await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    return Unit.Value;
  }
}