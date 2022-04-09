using System;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class FavoritesService
  {
    private readonly FavoritesRepository _favoritesRepo;

    public FavoritesService(FavoritesRepository favortiesRepo)
    {
      _favoritesRepo = favortiesRepo;
    }

    internal Favorite Create(Favorite favoriteData)
    {
      return _favoritesRepo.Create(favoriteData);
    }
  }
}