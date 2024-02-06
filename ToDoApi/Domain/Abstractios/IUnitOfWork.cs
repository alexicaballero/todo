using System.Threading;
using System.Threading.Tasks;

namespace TodoApi.Domain.Abstractios;

public interface IUnitOfWork
{
  Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}