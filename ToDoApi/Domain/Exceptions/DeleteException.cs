using System;

namespace TodoApi.Domain.Exceptions;

public class DeleteException : Exception
{
  public DeleteException(string name)
      : base($"\"{name}\" could not be deleted.")
  {
  }
}