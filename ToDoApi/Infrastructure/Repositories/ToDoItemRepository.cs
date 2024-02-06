using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Application.Abstractions;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Repositories;

internal class ToDoItemRepository : Repository<ToDoItem>, IToDoItemRepository
{
  public ToDoItemRepository(ToDoContext dbContext) : base(dbContext)
  {
  }

  public async Task<IEnumerable<ToDoItem>> GetAllByTodoListIdAsync(Guid toDoListId)
  {
    return await dbContext.ToDoItems.Where(t => t.ToDoListId == toDoListId).ToListAsync();
  }
}