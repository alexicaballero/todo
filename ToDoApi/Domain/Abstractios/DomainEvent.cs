using System;

namespace TodoApi.Domain.Abstractios;

public record DomainEvent : IDomainEvent
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}