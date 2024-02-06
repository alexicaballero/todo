using System;
using System.Collections.Generic;
using TodoApi.Domain.Abstractios;

namespace TodoApi.Domain.Entities;

public class ToDoList : Entity
{
  private readonly List<ToDoItem> items = new List<ToDoItem>();

  public string Title { get; set; } = string.Empty;

  public IReadOnlyCollection<ToDoItem> Items => items;

  public static ToDoList Create(string title)
  {
    var toDoList = new ToDoList()
    {
      Id = Guid.NewGuid(),
      Title = title
    };

    return toDoList;
  }

  public ToDoItem AddItem(string title)
  {
    var toDoItem = ToDoItem.Create(this.Id, title);
    this.items.Add(toDoItem);

    return toDoItem;
  }
}