using System;

namespace TodoApi.Domain.Abstractios;
public interface IDomainEvent
{
  DateTime DateOccurred { get; }
}