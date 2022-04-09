using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _ingredientsRepository;

    public IngredientsService(IngredientsRepository ingredientsRepository)
    {
      _ingredientsRepository = ingredientsRepository;
    }

    internal bool GetAll()
    {
      throw new NotImplementedException();
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int id)
    {
      throw new NotImplementedException();
    }

    internal Ingredient Create(Ingredient ingredientData)
    {
      throw new NotImplementedException();
    }

    internal object RemoveIngredient(int id, Account userInfo)
    {
      throw new NotImplementedException();
    }
  }
}