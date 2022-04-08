using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AllSpice.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {

    private readonly RecipesService _recipesService;

    private readonly IngredientsService _ingredientsService;

    private readonly StepsService _stepsService;

    private readonly FavoritesService _favoritesService;

    public RecipesController(RecipesService recipesService, IngredientsService ingredientsService, StepsService stepsService, FavoritesService favoritesService)
    {
      _recipesService = recipesService;
      _ingredientsService = ingredientsService;
      _stepsService = stepsService;
      _favoritesService = favoritesService;
    }



    [HttpGet]
    public ActionResult<List<Recipe>> GetAll()
    {
      try
      {
        List<Recipe> recipes = _recipesService.GetAll();
        return Ok(recipes);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> GetById(int id)
    {
      try
      {
        Recipe recipe = _recipesService.GetById(id);
        return Ok(recipe);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
    {
      try
      {
        Account UserInfo = await HttpContext.GetUserInfoAsync<Account>();
        recipeData.CreatorId = UserInfo.Id;
        Recipe recipe = _recipesService.Create(recipeData);
        recipe.Creator = UserInfo;
        return Created($"api/recipes/{recipe.Id}", recipe);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Remove(int id)

    {
      try
      {
        Account UserInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_recipesService.Remove(id, UserInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    


  }
}