using backend.Entities;
using backend.repositories.Interfaces;

namespace backend.repositories;

public class VoteRepository : AbstractRepository<Vote>
{
  public VoteRepository()
  {
    _entities = new List<Vote>();
  }
}