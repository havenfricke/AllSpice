using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class StepsService
  {
    private readonly StepsRepository _stepsRepository;

    public StepsService(StepsRepository stepsRepository)
    {
      _stepsRepository = stepsRepository;
    }

    internal List<Step> GetStepsByRecipeId(int recipeId)
    {
      throw new NotImplementedException();
    }

    internal Step CreateStep(Step stepData)
    {
      throw new NotImplementedException();
    }

    internal object RemoveStep(int id, Account userInfo)
    {
      throw new NotImplementedException();
    }
  }
}