using System;

namespace TodoApi.Domain.Exceptions;

public class CreateException : Exception
{
  public CreateException(string name)
      : base($"\"{name}\" could not be created.")
  {
  }
}