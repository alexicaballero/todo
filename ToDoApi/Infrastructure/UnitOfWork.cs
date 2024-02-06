using System.Threading;
using System.Threading.Tasks;
using TodoApi.Domain.Abstractios;

namespace TodoApi.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
  private readonly ToDoContext dbContext;

  public UnitOfWork(ToDoContext dbContext)
  {
    this.dbContext = dbContext;
  }

  public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    return dbContext.SaveChangesAsync(cancellationToken);
  }
}