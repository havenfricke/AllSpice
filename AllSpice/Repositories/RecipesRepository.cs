using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Recipe GetById(int id)
    {
      string sql = @"
            SELECT 
                r.*,
                a.* 
            FROM recipes r
            JOIN accounts a ON r.creatorId = a.id
            WHERE r.id = @id;
            ";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
      {
        // NOTE this is the populate creator
        recipe.Creator = account;
        return recipe;
      }, new { id }).FirstOrDefault();
    }

    internal string Remove(int id)
    {
      string sql = @"
            DELETE FROM recipes WHERE id = @id LIMIT 1;
            ";
      int rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected > 0)
      {
        return "delorted";
      }
      throw new Exception("could not delete");
    }

    internal List<RecipeFavoriteView> GetRecipesByAccountId(string id)
    {
      string sql = @"
          SELECT
            a.*,
            f.*,
            r.*
          FROM favorites f
          JOIN recipes r ON f.recipeId = r.id
          JOIN accounts a ON r.creatorId = a.id
          WHERE f.accountId = @id;
      ";
      List<RecipeFavoriteView> recipes = _db.Query<Account, Recipe, RecipeFavoriteView, RecipeFavoriteView>(sql, (a, f, r) =>
      {
        r.Creator = a;
        r.FavoriteId = f.Id;


        return r;
      }, new { id }).ToList<RecipeFavoriteView>();
      return recipes;
    }

    internal List<Recipe> GetAll()
    {
      string sql = @"
            SELECT
            r.*,
            a.*
            FROM recipes r
            JOIN accounts a WHERE a.id = r.creatorId;
            ";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
      {

        recipe.Creator = account;
        return recipe;
      }).ToList();
    }

    internal Recipe Create(Recipe recipeData)
    {
      string sql = @"
            INSERT INTO recipes
            (title, subTitle, category, creatorId, picture)
            VALUES
            (@Title, @SubTitle, @Category, @CreatorId, @Picture);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, recipeData);
      recipeData.Id = id;
      return recipeData;
    }
  }
}