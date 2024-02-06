using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Presentation.Abstractions;

[ApiController]
public abstract class ApiController : ControllerBase
{
  private readonly ISender sender;

  protected ApiController(ISender sender)
  {
    this.sender = sender;
  }
}