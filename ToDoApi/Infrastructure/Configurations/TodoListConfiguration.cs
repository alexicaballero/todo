using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Configurations;

public class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList>
{
  public void Configure(EntityTypeBuilder<ToDoList> builder)
  {
    builder.ToTable(nameof(ToDoList));

    builder.HasKey(e => e.Id);
  }
}