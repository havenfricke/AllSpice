using System;
using System.Threading.Tasks;
using spiceGirls.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CodeWorks.Auth0Provider;
using spiceGirls.Services;

namespace spiceGirls.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly RecipesService _rs;

    public AccountController(AccountService accountService, RecipesService rs)
    {
      _accountService = accountService;
      _rs = rs;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("favorites")]
    [Authorize]
    public async Task<ActionResult<List<RecipeFavoriteView>>> GetMyFavorites()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<RecipeFavoriteView> favorites = _rs.GetFavoritesByAccountId(userInfo.Id);
        return Ok(favorites);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }


}