using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spiceGirls.Models;
using spiceGirls.Services;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _rs;
    private readonly IngredientsService _is;
    private readonly StepsService _ss;

    public RecipesController(RecipesService rs, IngredientsService @is, StepsService ss)
    {
      _rs = rs;
      _is = @is;
      _ss = ss;
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAll()
    {
      try
      {
        List<Recipe> recipes = _rs.GetAll();
        return Ok(recipes);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/ingredients")]
    public ActionResult<List<Ingredient>> GetAllIngredients(int id)
    {
      try
      {
        List<Ingredient> ingredients = _is.GetAll(id);
        return Ok(ingredients);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/steps")]
    public ActionResult<List<Ingredient>> GetAllSteps(int id)
    {
      try
      {
        List<Step> steps = _ss.GetAll(id);
        return Ok(steps);
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
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _rs.Create(recipeData);
      recipe.Creator = userInfo;
      return Created($"api/recipes/{recipe.Id}", recipe);

    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Remove(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_rs.Remove(id, userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}