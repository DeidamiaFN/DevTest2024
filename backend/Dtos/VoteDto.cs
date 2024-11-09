namespace backend.Dtos;

public class VoteDto
{
  public int pollId { get; set; }
  public int optionId { get; set; }
  public string voterEmail { get; set; }
}