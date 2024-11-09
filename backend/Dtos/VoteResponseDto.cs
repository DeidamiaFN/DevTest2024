namespace backend.Dtos;

public class VoteResponseDto
{
  public int Id { get; set; }
  public int pollId { get; set; }
  public int optionId { get; set; }
  public string voterEmail { get; set; }
}