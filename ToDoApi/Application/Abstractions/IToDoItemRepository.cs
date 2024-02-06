using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Domain.Entities;

namespace TodoApi.Application.Abstractions;

public interface IToDoItemRepository : IRepository<ToDoItem>
{
  Task<IEnumerable<ToDoItem>> GetAllByTodoListIdAsync(Guid toDoListId);
}