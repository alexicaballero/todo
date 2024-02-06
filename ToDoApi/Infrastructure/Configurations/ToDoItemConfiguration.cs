using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Configurations;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
  public void Configure(EntityTypeBuilder<ToDoItem> builder)
  {
    builder.ToTable(nameof(ToDoItem));

    builder.HasKey(e => e.Id);

    builder.HasOne(e => e.TodoList)
           .WithMany(e => e.Items)
           .HasForeignKey(e => e.ToDoListId);
  }
}