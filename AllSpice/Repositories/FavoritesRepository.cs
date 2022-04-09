using System.Data;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
  public class FavoritesRepository
  {
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Favorite Create(Favorite favoriteData)
    {
      string sql = @"
      INSERT INTO favorites
      (recipeId, accountId)
      VALUES
      (@recipeId, accountId@);
      SELECT LAST_INSERTID();
      ";
      int id = _db.ExecuteScalar<int>(sql, favoriteData);
      favoriteData.Id = id;
      return favoriteData;
    }
  }
}