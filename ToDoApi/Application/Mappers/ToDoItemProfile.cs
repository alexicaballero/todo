using AutoMapper;
using TodoApi.Application.Dtos;
using TodoApi.Domain.Entities;

namespace TodoApi.Application.Mappers;

public class ToDoItemProfile : Profile
{
  public ToDoItemProfile()
  {
    CreateMap<ToDoItem, ToDoItemDto>().ReverseMap();
  }
}