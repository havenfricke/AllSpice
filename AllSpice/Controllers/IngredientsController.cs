using AllSpice.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _ingredientsService;
    public IngredientsController(IngredientsService ingredientsService)
    {
      _ingredientsService = ingredientsService;
    }


  }
}