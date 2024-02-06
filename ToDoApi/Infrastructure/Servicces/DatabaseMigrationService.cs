using Microsoft.EntityFrameworkCore;
using TodoApi.Infrastructure;

namespace ToDoApi.Infrastructure.Servicces;

internal class DatabaseMigrationService
{
  private readonly ToDoContext toDoContext;

  public DatabaseMigrationService(ToDoContext toDoContext)
  {
    this.toDoContext = toDoContext;
  }

  public void ApplyMigrations()
  {
    toDoContext.Database.Migrate();
  }
}