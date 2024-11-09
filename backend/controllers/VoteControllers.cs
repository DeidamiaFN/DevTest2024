using AutoMapper;
using backend.Dtos;
using backend.Entities;
using backend.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Controller]
[Route("api/[controller]")]
public class VoteControllers : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IVoteServicce _voteService;


  public VoteControllers(IMapper mapper, IVoteServicce voteService)
  {
    _mapper = mapper;
    _voteService = voteService;
  }

  [HttpGet("{id}")]
  public async  Task<ActionResult<Vote>> GetVote([FromRoute]int id)
  {
    var vote = _voteService.GetById(id);
    var voteDto = _mapper.Map<Vote>(vote.Result);
    
    return Ok(voteDto);
  }
    
  [HttpPost("{id}/vote")]
  public async Task<ActionResult<Vote>> Post([FromRoute] int id, [FromBody] VoteNoPollDto vote)
  {
    var voteNoIdDto = _mapper.Map<VoteDto>((vote, id));
    var voteDto = _mapper.Map<Vote>((voteNoIdDto, id));
    var newVote = await _voteService.Add(voteDto);
    
    return CreatedAtAction(nameof(GetVote), new { id = newVote.Id }, voteDto);
  }
}