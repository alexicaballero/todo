using System;
using TodoApi.Domain.Abstractios;
using TodoApi.Domain.Events;

namespace TodoApi.Domain.Entities;

public class ToDoItem : Entity
{
  public Guid ToDoListId { get; private set; } = Guid.NewGuid();

  public string Description { get; set; } = string.Empty;

  public bool Done { get; private set; } = false;

  public ToDoList TodoList { get; private set; }

  public static ToDoItem Create(Guid TodoListId, string description)
  {
    var toDoItem = new ToDoItem()
    {
      Id = Guid.NewGuid(),
      ToDoListId = TodoListId,
      Description = description,
      Done = false
    };

    return toDoItem;
  }

  public void MarkComplete()
  {
    Done = true;
    Events.Add(new ToDoItemCompletedEvent(this));
  }
}