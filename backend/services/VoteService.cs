using backend.Entities;
using backend.repositories;
using backend.services.Interfaces;

namespace backend.services;

public class VoteService : IVoteServicce
{
  private readonly VoteRepository _voteRepository;

  public VoteService(VoteRepository voteRepository)
  {
    _voteRepository = voteRepository;
  }

  public Task<Vote> Add(Vote entity)
  {
    return _voteRepository.Add(entity);
  }

  public Task<List<Vote>> GetAll()
  {
    return _voteRepository.GetAll();
  }

  public Task<Vote> GetById(int id)
  {
    return _voteRepository.GetById(id);
  }
}