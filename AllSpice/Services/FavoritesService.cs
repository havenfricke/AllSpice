using System;
using spiceGirls.Models;
using spiceGirls.Repositories;

namespace spiceGirls.Services
{
  public class FavoritesService
  {
    private readonly FavoritesRepository _favoritesRepo;

    public FavoritesService(FavoritesRepository favoritesRepo)
    {
      _favoritesRepo = favoritesRepo;
    }

    internal object Create(Favorite favoriteData)
    {
      return _favoritesRepo.Create(favoriteData);
    }

    internal object Remove(int id, Account userInfo)
    {
      Favorite favorite = _favoritesRepo.GetById(id);
      if (favorite.AccountId != userInfo.Id)
      {
        throw new Exception("you can't do that nice try.");
      }
      return _favoritesRepo.Remove(id);
    }
  }
}