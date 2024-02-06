using MediatR;
using System.Collections.Generic;
using TodoApi.Application.Dtos;

namespace ToDoApi.Application.UseCases.TodoLists.Queries.GetAll;

public class GetAllRequest : IRequest<IEnumerable<ToDoListDto>>
{
}