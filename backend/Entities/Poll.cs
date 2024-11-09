namespace backend.Entities;

public class Poll : IEntity
{
  public int Id { get; set; }
  public string Name { get; set; }
}