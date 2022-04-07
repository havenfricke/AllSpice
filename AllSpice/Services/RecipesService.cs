using AllSpice.Repositories;

namespace AllSpice.Controllers
{
  public class RecipesService
  {

    private readonly RecipesRepository _recipesRepository;

    public RecipesService(RecipesRepository recipesRepository)
    {
      _recipesRepository = recipesRepository;
    }
  }
}