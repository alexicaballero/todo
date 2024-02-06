using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoApi.Application.Dtos;
using TodoApi.Presentation.Abstractions;
using ToDoApi.Application.UseCases.TodoLists.Commands.Create;
using ToDoApi.Application.UseCases.TodoLists.Commands.CreateSeedData;
using ToDoApi.Application.UseCases.TodoLists.Commands.Delete;
using ToDoApi.Application.UseCases.TodoLists.Queries.GetAll;
using ToDoApi.Application.UseCases.TodoLists.Queries.GetById;

namespace TodoApi.Presentation.Controllers;

[Route("api/todo-lists")]
public class ToDoListsController : ApiController
{
  private readonly ISender sender;

  public ToDoListsController(ISender sender) : base(sender)
  {
    this.sender = sender;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<ToDoListDto>>> GetAllAsync(CancellationToken cancellationToken)
  {
    var query = new GetAllRequest();
    var response = await sender.Send(query, cancellationToken);

    return Ok(response);
  }

  [HttpGet("{todo-list-id}")]
  public async Task<ActionResult<ToDoListDto>> GetByIdAsync([FromRoute(Name = "todo-list-id")] Guid toDoListId, CancellationToken cancellationToken)
  {
    var query = new GetByIdRequest(toDoListId);
    var response = await sender.Send(query, cancellationToken);

    return Ok(response);
  }

  [HttpPost]
  public async Task<ActionResult<ToDoListDto>> CreateAsync([FromBody] CreateRequest request, CancellationToken cancellationToken)
  {
    var response = await sender.Send(request, cancellationToken);

    return Ok(response);
  }

  [HttpDelete("{todo-list-id}")]
  public async Task<ActionResult> DeleteAsyc([FromRoute(Name = "todo-list-id")] Guid toDoItemId, CancellationToken cancellationToken)
  {
    var request = new DeleteRequest(toDoItemId);

    await sender.Send(request, cancellationToken);

    return Ok();
  }

  [HttpPost("seed-data")]
  public async Task<ActionResult<ToDoListDto>> CreateSeedDataAsync(CancellationToken cancellationToken)
  {
    var request = new CreateSeedDataRequest();
    var response = await sender.Send(request, cancellationToken);

    return Ok(response);
  }
}