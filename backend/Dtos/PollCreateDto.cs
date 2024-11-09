namespace backend.Dtos;

public class PollCreateDto
{
  public string Name { get; set; }
  public List<OptionPostDto> Options { get; set; }
  
}