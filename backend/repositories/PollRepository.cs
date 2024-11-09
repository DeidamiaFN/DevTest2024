using backend.Entities;
using backend.repositories.Interfaces;

namespace backend.repositories;

public class PollRepository : AbstractRepository<Poll>
{
  public PollRepository()
  {
    _entities = new List<Poll>();
  }
  
  
}