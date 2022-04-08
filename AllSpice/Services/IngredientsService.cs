using System;
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
  }
}