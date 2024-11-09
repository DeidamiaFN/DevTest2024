using backend.Entities;

namespace backend.repositories.Interfaces;

public interface IRepository<T> where T : IEntity
{
  public Task<T> Add(T entity);
  public Task<List<T>> GetAll();
  
  public Task<T?> GetById(int id);

}