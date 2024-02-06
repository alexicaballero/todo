using AutoMapper;
using TodoApi.Application.Dtos;
using TodoApi.Domain.Entities;

namespace TodoApi.Application.Mappers;

public class ToDoListProfile : Profile
{
  public ToDoListProfile()
  {
    CreateMap<ToDoList, ToDoListDto>().ReverseMap();
  }
}