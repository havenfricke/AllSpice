namespace AllSpice.Models
{
  public class Step
  {
    public int Id { get; set; }
    public int StepOrder { get; set; }
    public string Body { get; set; }
    public int RecipeId { get; set; }

  }
}