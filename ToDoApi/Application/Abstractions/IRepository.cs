using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TodoApi.Application.Abstractions;

public interface IRepository<TEntity> where TEntity : class
{
  Task<TEntity?> GetByIdAsync(Guid id);

  Task<IEnumerable<TEntity>> GetAllAsync();

  Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filter = null,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                    int? top = null,
                                    int? skip = null,
                                    params string[] includeProperties);

  Task<TEntity> AddAsync(TEntity entity);

  Task<TEntity> UpdateAsync(TEntity entity);

  Task DeleteAsync(TEntity entity);

  Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter);
}