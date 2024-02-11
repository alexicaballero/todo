using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Application.Dtos;
using TodoApi.Presentation.Abstractions;
using ToDoApi.Application.UseCases.TodoItems.Commands.Create;
using ToDoApi.Application.UseCases.TodoItems.Commands.Delete;
using ToDoApi.Application.UseCases.TodoItems.Commands.MarkAsDone;
using ToDoApi.Application.UseCases.TodoItems.Queries.GetByTodoList;

namespace TodoApi.Presentation.Controllers;

[Route("api/todo-items")]
public class ToDoItemsController : ApiController
{
  private readonly ISender sender;

  public ToDoItemsController(ISender sender) : base(sender)
  {
    this.sender = sender;
  }

  [HttpGet("todo-list/{todo-list-id}")]
  public async Task<ActionResult<IEnumerable<ToDoItemDto>>> GetAllAync([FromRoute(Name = "todo-list-id")] Guid toDoListId, CancellationToken cancellationToken)
  {
    var query = new GetByTodoListRequest(toDoListId);
    var response = await sender.Send(query, cancellationToken);

    return Ok(response);
  }

  [HttpPost]
  public async Task<ActionResult<ToDoItemDto>> CreateAsync([FromBody] CreateRequest request, CancellationToken cancellationToken)
  {
    var response = await sender.Send(request, cancellationToken);

    return Ok(response);
  }

  [HttpPatch("{todo-item-id}/done/{is-done}")]
  public async Task<ActionResult<ToDoItemDto>> MarkAsDoneAsync([FromRoute(Name = "todo-item-id")] Guid toDoItemId, [FromRoute(Name = "is-done")] bool isDone, CancellationToken cancellationToken)
  {
    var request = new MarkAsDoneRequest(toDoItemId, isDone);
    var response = await sender.Send(request, cancellationToken);

    return Ok(response);
  }

  [HttpDelete("{todo-item-id}")]
  public async Task<ActionResult> DeleteAsyc([FromRoute(Name = "todo-item-id")] Guid toDoItemId, CancellationToken cancellationToken)
  {
    var request = new DeleteRequest(toDoItemId);

    await sender.Send(request, cancellationToken);

    return Ok();
  }
}