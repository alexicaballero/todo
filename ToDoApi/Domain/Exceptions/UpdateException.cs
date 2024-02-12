using System;

namespace TodoApi.Domain.Exceptions;

public class UpdateException : Exception
{
  public UpdateException(string name)
      : base($"\"{name}\" could not be updated.")
  {
  }
}