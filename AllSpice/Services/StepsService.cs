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
      List<Step> found = _stepsRepository.GetStepsByRecipeId(recipeId);

      return found;
    }

    internal Step CreateStep(Step stepData)
    {
      return _stepsRepository.Create(stepData);
    }

    internal string RemoveStep(int id, Account userInfo)
    {
      Step step = _stepsRepository.GetStepById(id);
      if (step.creatorId != userInfo.Id)
      {
        throw new Exception("You are not allowed to delete this.");
      }

      return _stepsRepository.RemoveStep(id);
    }
  }
}