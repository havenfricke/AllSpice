using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spiceGirls.Models;
using spiceGirls.Services;

namespace spiceGirls.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FavoritesController : ControllerBase
  {
    private readonly FavoritesService _fs;

    public FavoritesController(FavoritesService fs)
    {
      _fs = fs;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Favorite>> Create([FromBody] Favorite favoriteData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        favoriteData.AccountId = userInfo.Id;
        return Ok(_fs.Create(favoriteData));

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
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

        return Ok(_fs.Remove(id, userInfo));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}