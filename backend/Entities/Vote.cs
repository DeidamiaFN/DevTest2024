namespace backend.Entities;

public class Vote : IEntity
{
  public int Id { get; set; }
  public int pollId { get; set; }
  public int optionId { get; set; }
  public string voterEmail { get; set; }

}