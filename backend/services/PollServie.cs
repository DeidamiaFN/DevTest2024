using backend.Entities;
using backend.repositories;

namespace backend.services.Interfaces;

public class PollServie : IPollService
{
  private readonly PollRepository _pollRepository;
  private readonly IOptionService _optionService;

  public PollServie(PollRepository pollRepository, IOptionService optionService)
  {
    _pollRepository = pollRepository;
    _optionService = optionService;
  }

  public Task<Poll> Add(Poll entity)
  {
    var response = _pollRepository.Add(entity);
    return response;
  }

  public Task<List<Poll>> GetAll()
  {
    return _pollRepository.GetAll();
  }

  public Task<Poll> GetById(int id)
  {
    return _pollRepository.GetById(id);
  }


  public Task<List<Option>> GetOptions(int id)
  {
    var optionIds = _optionService.getIdsByPollID(id);
    var options = new List<Option>();

    foreach (var idsOptionId in optionIds.Result)
    {
      var option = _optionService.GetById(idsOptionId);
      options.Add(option.Result);
    }
    
    return Task.FromResult(options);
  }

  public Task<bool> Vote(int id)
  {
    throw new NotImplementedException();
  }

  public Task<bool> AddOptions(int id, List<Option> options)
  {
    var poll = _pollRepository.GetById(id);
    if (poll == null)
      return Task.FromResult(false);
    
    foreach (var option in options)
    {
      _optionService.Add(option);
    } 
    
    return Task.FromResult(true);
  }
}