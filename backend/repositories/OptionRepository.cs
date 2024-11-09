using backend.Entities;
using backend.repositories.Interfaces;

namespace backend.repositories;

public class OptionRepository : AbstractRepository<Option>
{
  public OptionRepository()
  {
    _entities = new List<Option>();
  }

  public Task<bool> Vote(int id)
  {
    var option = _entities.FirstOrDefault(x => x.Id == id);
    if (option == null)
      return Task.FromResult(false);
    option.Votes++;
    return Task.FromResult(true);
  }
  
  public Task<List<int>> getIdsByPollID(int pollID)
  {
    var ids = new List<int>();
    foreach (var entity in _entities)
    {
      if(entity.PollId == pollID)
        ids.Add(entity.Id);
    }
    
    return Task.FromResult(ids);
  }
}