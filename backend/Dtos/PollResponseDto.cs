namespace backend.Dtos;

public class PollResponseDto
{
  public int Id { get; set; }
  public string Name { get; set; }
  public List<OptionsDto> Options { get; set; }
}