using AutoMapper;
using backend.Dtos;
using backend.Entities;
using backend.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Controller]
[Route("api/v1/polls")]
public class PollController : ControllerBase
{
  private readonly IPollService _pollService;
  private readonly IMapper _mapper;
  private int PollCounter;
  private int OptionCounter;
  private int VoteCounter;
  
  public PollController(IPollService pollService, IMapper mapper)
  {
    _pollService = pollService;
    _mapper = mapper;
    PollCounter = 0;
    OptionCounter = 0;
    VoteCounter = 0;
  }
  
  [HttpGet("{id}")]
  public async  Task<ActionResult<Poll>> GetOption([FromRoute]int id)
  {
    var option = _pollService.GetById(id);
    var optionDto = _mapper.Map<Poll>(option.Result);
    return Ok(optionDto);
  }
  
  [HttpPost]
  public async Task<ActionResult<PollResponseDto>> Post([FromBody] PollCreateDto poll)
  {
    var pollEntity = _mapper.Map<Poll>((poll.Name, PollCounter));
    var pollResponse = await _pollService.Add(pollEntity);
    var optionsDto = new List<Option>();
    foreach (var option in poll.Options)
    {
      optionsDto.Add(_mapper.Map<Option>((option, OptionCounter++, PollCounter, 0)));
    }
    await _pollService.AddOptions(PollCounter, optionsDto);
    
    var responseDto = _mapper.Map<PollResponseDto>((pollEntity, optionsDto));
    PollCounter++;
    return Ok(responseDto);
  }}