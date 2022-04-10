using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using spiceGirls.Models;

namespace spiceGirls.Repositories
{
  public class StepsRepository
  {
    private readonly IDbConnection _db;

    public StepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Step Create(Step stepData)
    {
      string sql = @"
            INSERT INTO steps
            (stepOrder, body, recipeId)
            VALUES
            (@StepOrder, @Body, @RecipeId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, stepData);
      stepData.Id = id;
      return stepData;
    }

    internal Step GetById(int id)
    {
      string sql = @"
            SELECT 
                s.*
            FROM steps s
            
            WHERE s.id = @id;
            ";
      return _db.Query<Step>(sql
     , new { id }).FirstOrDefault();
    }

    internal void Update(Step original)
    {
      string sql = @"
            UPDATE steps
            SET
            body = @Body,
            stepOrder = @StepOrder
            
            WHERE id = @Id;
            ";
      _db.Execute(sql, original);

    }

    internal object Remove(int id)
    {
      string sql = @"
            DELETE FROM steps WHERE id = @id LIMIT 1;
            ";
      int rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected > 0)
      {
        return "delorted";
      }
      throw new Exception("could not delete");
    }

    internal List<Step> GetAll(int id)
    {
      string sql = @"
            SELECT
            s.*
            FROM steps s
            WHERE s.recipeId = @id;
            ";
      List<Step> steps = _db.Query<Step>(sql, new { id }).ToList();
      return steps;
    }
  }
}