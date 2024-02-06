using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure;

public class ToDoContext : DbContext
{
  public DbSet<ToDoList> ToDoLists { get; set; }
  public DbSet<ToDoItem> ToDoItems { get; set; }

  public ToDoContext(DbContextOptions options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}