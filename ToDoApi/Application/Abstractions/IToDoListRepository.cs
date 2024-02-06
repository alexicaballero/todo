using TodoApi.Domain.Entities;

namespace TodoApi.Application.Abstractions;

public interface IToDoListRepository : IRepository<ToDoList>
{ }