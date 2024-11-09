using backend.Entities;
using Microsoft.Extensions.Options;

namespace backend.services.Interfaces;

public interface IPollService : IService<Poll>
{
  public Task<List<Option>> GetOptions(int id);
  
  public Task<bool> Vote(int id);
  
  public Task<bool> AddOptions(int id, List<Option> options);

}