using backend.Entities;

namespace backend.services.Interfaces;

public interface IOptionService : IService<Option>
{
  public Task<bool> Vote(int id);

  public Task<List<int>> getIdsByPollID(int pollID);
}