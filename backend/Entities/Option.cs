namespace backend.Entities;

public class Option : IEntity
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int Votes { get; set; }
}