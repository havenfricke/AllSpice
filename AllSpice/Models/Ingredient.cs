namespace AllSpice.Models
{
  public class Ingredient
  {
    public int Id { get; set; }
    public string Quantity { get; set; }
    public string creatorId { get; set; }
    public int RecipeId { get; set; }

    //virtuals

    public Recipe Recipe { get; set; }

    public Account Creator { get; set; }
  }
}