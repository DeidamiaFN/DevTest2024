using backend.Entities;
using backend.repositories;
using backend.services.Interfaces;

namespace backend.services;

public class OptionService : IOptionService
{
  public readonly OptionRepository _optionRepository;

  public OptionService(OptionRepository optionRepository)
  {
    _optionRepository = optionRepository;
  }

  public Task<Option> Add(Option entity)
  {
    return _optionRepository.Add(entity);
  }

  public Task<List<Option>> GetAll()
  {
    return _optionRepository.GetAll();
  }

  public Task<Option> GetById(int id)
  {
    return _optionRepository.GetById(id);
  }

  public Task<bool> Vote(int id)
  {
    return _optionRepository.Vote(id);
  }
}