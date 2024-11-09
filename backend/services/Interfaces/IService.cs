using backend.Entities;

namespace backend.services.Interfaces;

public interface IService<T> where T : IEntity
{
  public Task<T> Add(T entity);
  public Task<List<T>> GetAll();
  
  public Task<T> GetById(int id);
}