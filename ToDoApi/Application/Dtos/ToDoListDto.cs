using System;
using System.Collections.Generic;

namespace TodoApi.Application.Dtos;

public class ToDoListDto
{
  public Guid Id { get; set; } = Guid.NewGuid();

  public string Title { get; set; } = string.Empty;

  // public ICollection<ToDoItemDto> Items { get; set; } = new List<ToDoItemDto>();
}