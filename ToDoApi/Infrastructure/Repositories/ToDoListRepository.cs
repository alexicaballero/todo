using TodoApi.Application.Abstractions;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Repositories;

internal class ToDoListRepository : Repository<ToDoList>, IToDoListRepository
{
  public ToDoListRepository(ToDoContext dbContext) : base(dbContext)
  {
  }
}