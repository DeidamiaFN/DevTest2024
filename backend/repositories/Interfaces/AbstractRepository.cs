using backend.Entities;

namespace backend.repositories.Interfaces;

public class AbstractRepository<T> : IRepository<T> where T : IEntity
{
  protected List<T> _entities;
  public Task<T> Add(T entity)
  {
    _entities.Add(entity);
    return Task.FromResult(entity);
  }

  public Task<List<T>> GetAll()
  {
    return Task.FromResult(_entities);
  }

  public Task<T?> GetById(int id)
  {
    var found = _entities.FirstOrDefault(x => x.Id == id);
    return Task.FromResult(found);
  }
}