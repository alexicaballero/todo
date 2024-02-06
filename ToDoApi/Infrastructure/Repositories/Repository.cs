using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoApi.Application.Abstractions;

namespace TodoApi.Infrastructure.Repositories;

internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
  protected readonly ToDoContext dbContext;
  private readonly DbSet<TEntity> dbSet;

  public Repository(ToDoContext dbContext)
  {
    this.dbContext = dbContext;
    dbSet = dbContext.Set<TEntity>();
  }

  #region Methods

  /// <summary>
  /// Adds an entity.
  /// </summary>
  /// <param name="entity">The entity to add</param>
  /// <returns>The entity that was added</returns>
  public async Task<TEntity> AddAsync(TEntity entity)
  {
    await dbSet.AddAsync(entity);
    return entity;
  }

  /// <summary>
  /// Updates an entity.
  /// </summary>
  /// <param name="entity">The entity to delete</param>
  /// <returns><see cref="Task"/></returns>
  public Task<TEntity> UpdateAsync(TEntity entity)
  {
    dbSet.Update(entity);
    return Task.FromResult(entity);
  }

  /// <summary>
  /// Deletes an entity.
  /// </summary>
  /// <param name="entity">The entity to delete</param>
  /// <returns><see cref="Task"/></returns>
  public Task DeleteAsync(TEntity entity)
  {
    dbSet.Remove(entity);
    return Task.CompletedTask;
  }

  /// <summary>
  /// Deletes entities based on a condition.
  /// </summary>
  /// <param name="filter">The condition the entities must fulfil to be deleted</param>
  /// <returns><see cref="Task"/></returns>
  public Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter)
  {
    var entities = dbSet.Where(filter);

    dbSet.RemoveRange(entities);

    return Task.CompletedTask;
  }

  /// <summary>
  /// Gets a collection of all entities.
  /// </summary>
  /// <returns>A collection of all entities</returns>
  public async Task<IEnumerable<TEntity>> GetAllAsync()
  {
    return await dbSet.ToListAsync();
  }

  /// <summary>
  /// Gets an entity by ID.
  /// </summary>
  /// <param name="id">The ID of the entity to retrieve</param>
  /// <returns>The entity object if found, otherwise null</returns>
  public async Task<TEntity?> GetByIdAsync(Guid id)
  {
    return await dbSet.FindAsync(id);
  }

  /// <summary>
  /// Gets a collection of entities based on the specified criteria.
  /// </summary>
  /// <param name="filter">The condition the entities must fulfil to be returned</param>
  /// <param name="orderBy">The function used to order the entities</param>
  /// <param name="top">The number of records to limit the results to</param>
  /// <param name="skip">The number of records to skip</param>
  /// <param name="includeProperties">Any other navigation properties to include when returning the collection</param>
  /// <returns>A collection of entities</returns>
  public async Task<IEnumerable<TEntity>> GetManyAsync(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      int? top = null,
      int? skip = null,
      params string[] includeProperties)
  {
    IQueryable<TEntity> query = dbSet;

    if (filter != null)
    {
      query = query.Where(filter);
    }

    if (includeProperties.Length > 0)
    {
      query = includeProperties.Aggregate(query, (theQuery, theInclude) => theQuery.Include(theInclude));
    }

    if (orderBy != null)
    {
      query = orderBy(query);
    }

    if (skip.HasValue)
    {
      query = query.Skip(skip.Value);
    }

    if (top.HasValue)
    {
      query = query.Take(top.Value);
    }

    return await query.ToListAsync();
  }

  #endregion Methods
}