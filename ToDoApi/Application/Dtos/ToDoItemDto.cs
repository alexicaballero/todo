using System;

namespace TodoApi.Application.Dtos;

public class ToDoItemDto
{
  public Guid Id { get; set; } = Guid.NewGuid();

  public Guid TodoListId { get; set; } = Guid.NewGuid();

  public string Description { get; set; } = string.Empty;

  public bool Done { get; set; } = false;

  // public ToDoListDto ToDoList { get; private set; }
}