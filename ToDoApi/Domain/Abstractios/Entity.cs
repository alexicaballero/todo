using System;
using System.Collections.Generic;

namespace TodoApi.Domain.Abstractios;

public abstract class Entity
{
  public Guid Id { get; protected set; } = Guid.NewGuid();

  public List<IDomainEvent> Events = new List<IDomainEvent>();
}