using System;
using System.Collections.Generic;
using AllSpice.Models;
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

    internal List<Recipe> GetAll()
    {
      throw new NotImplementedException();
    }

    internal Recipe GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal Recipe Create(Recipe recipeData)
    {
      throw new NotImplementedException();
    }
  }
}