namespace backend.Dtos;

public class OptionsDto
{
  public int Id { get; set; }
  public int PollId { get; set; }
  public string Name { get; set; }
  public uint Votes { get; set; }
}