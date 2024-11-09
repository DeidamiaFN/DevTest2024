using AutoMapper;
using backend.Dtos;
using backend.Entities;
using backend.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Controller]
[Route("api/[controller]")]
public class OptionControllers : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IOptionService _optionService;


  public OptionControllers(IMapper mapper, IOptionService optionService)
  {
    _mapper = mapper;
    _optionService = optionService;
  }

  [HttpGet("{id}")]
  public async  Task<ActionResult<Option>> GetOption([FromRoute]int id)
  {
    var option = _optionService.GetById(id);
    var optionDto = _mapper.Map<Option>(option.Result);
    
    return Ok(optionDto);
  }
    
  [HttpPost]
  public async Task<ActionResult<Option>> Post([FromBody] OptionPostDto option)
  {
    var voteDto = _mapper.Map<Option>((option, 1, 2, 0));
    var newOption = await _optionService.Add(voteDto);
    
    return CreatedAtAction(nameof(GetOption), new { id = newOption.Id }, voteDto);
  }
}