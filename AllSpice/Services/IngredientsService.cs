using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _ingredientsRepo;
    private readonly RecipesRepository _recipesRepo;

    public IngredientsService(IngredientsRepository ingredientsRepo, RecipesRepository recipesRepo)
    {
      _ingredientsRepo = ingredientsRepo;
      _recipesRepo = recipesRepo;
    }

    internal Ingredient Create(Ingredient ingredientData, Account userInfo)
    {
      Recipe recipe = _recipesRepo.GetById(ingredientData.RecipeId);
      ingredientData.RecipeId = recipe.Id;
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new System.Exception("You don't own this recipe");
      }
      return _ingredientsRepo.Create(ingredientData);
    }

    internal List<Ingredient> GetAll(int id)
    {
      return _ingredientsRepo.GetAll(id);
    }

    internal Ingredient Update(Ingredient ingredientUpdate, Account userInfo)
    {
      Recipe recipe = _recipesRepo.GetById(ingredientUpdate.RecipeId);
      ingredientUpdate.RecipeId = recipe.Id;
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new System.Exception("This isn't your ingredient");
      }
      Ingredient original = _ingredientsRepo.GetById(ingredientUpdate.Id);
      original.Name = ingredientUpdate.Name ?? original.Name;
      original.Quantity = ingredientUpdate.Quantity ?? original.Name;
      if (original != null)
      {

        _ingredientsRepo.Update(original);
      }
      return original;
    }

    internal object Remove(int id, Account userInfo)
    {
      Ingredient ingredient = _ingredientsRepo.GetById(id);
      Recipe recipe = _recipesRepo.GetById(ingredient.RecipeId);
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new Exception("you can't do that nice try.");
      }
      return _ingredientsRepo.Remove(id);
    }
  }
}