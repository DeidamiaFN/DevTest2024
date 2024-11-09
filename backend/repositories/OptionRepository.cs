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
}