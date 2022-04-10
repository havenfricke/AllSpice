using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using spiceGirls.Models;

namespace spiceGirls.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Ingredient Create(Ingredient ingredientData)
    {
      string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId)
            VALUES
            (@Name, @Quantity, @RecipeId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, ingredientData);
      ingredientData.Id = id;
      return ingredientData;
    }

    internal List<Ingredient> GetAll(int id)
    {
      string sql = @"
            SELECT
            i.*
            FROM ingredients i
            WHERE i.recipeId = @id;
            ";
      List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { id }).ToList();
      return ingredients;

    }

    internal Ingredient GetById(int id)
    {
      string sql = @"
            SELECT 
                i.*
            FROM ingredients i
            
            WHERE i.id = @id;
            ";
      return _db.Query<Ingredient>(sql
     , new { id }).FirstOrDefault();
    }

    internal Ingredient Update(Ingredient original)
    {
      string sql = @"
            UPDATE ingredients
            SET
            name = @Name,
            quantity = @Quantity
            
            WHERE id = @Id;
            ";
      _db.Execute(sql, original);
      return original;
    }

    internal object Remove(int id)
    {
      string sql = @"
            DELETE FROM ingredients WHERE id = @id LIMIT 1;
            ";
      int rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected > 0)
      {
        return "delorted";
      }
      throw new Exception("could not delete");
    }
  }
}