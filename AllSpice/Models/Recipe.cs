namespace spiceGirls.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Category { get; set; }
        public string CreatorId { get; set; }
        public string Picture { get; set; }
        public Account? Creator { get; set; }
    }
    public class RecipeFavoriteView : Recipe
    {
        public int FavoriteId { get; set; }

    }
}