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
      return _recipesRepository.GetAll();
    }

    internal Recipe GetById(int id)
    {
      return _recipesRepository.GetById(id);
    }

    internal Recipe Create(Recipe recipeData)
    {
      return _recipesRepository.Create(recipeData);
    }

    internal string Remove(int id, Account user)
    {
      Recipe recipe = _recipesRepository.GetById(id);
      if (recipe.CreatorId != user.Id)
      {
        throw new Exception("You are not allowed to delete this");
      }
      return _recipesRepository.Remove(id);
    }
  }
}