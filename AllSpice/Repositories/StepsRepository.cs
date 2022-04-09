using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
  public class StepsRepository
  {
    private readonly IDbConnection _db;

    public StepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Step> GetStepsByRecipeId(int recipeId)
    {
      string sql = @"
      SELECT
      s.*,
      r.*
      FROM
      steps s
      JOIN
      recipes r
      WHERE
      @recipeId = r.id;
      ";
      return _db.Query<Step>(sql, new { recipeId }).ToList<Step>();
    }

    internal Step Create(Step stepData)
    {
      string sql = @"
      INSERT INTO
        steps 
        (
        stepNumber, 
        body, 
        recipeId, 
        creatorId
          )
      VALUES
      (
       @stepNumber,
       @body,
       @recipeId,
       @creatorId
      );";
      int id = _db.ExecuteScalar<int>(sql, stepData);
      stepData.Id = id;
      return stepData;
    }

    internal Step GetStepById(int id)
    {
      string sql = @"
      SELECT
      *
      FROM
      steps
      WHERE
      id = @id;
      ";
      return _db.QueryFirstOrDefault<Step>(sql, new { id });
    }

    internal string RemoveStep(int id)
    {
      string sql = @"
      DELETE FROM
      steps
      WHERE
      id = @id
      LIMIT 1;
      ";
      int rowAffected = _db.Execute(sql, new { id });
      if (rowAffected > 0)
      {
        return "deletey completey";
      }
      throw new Exception("could not delete");
    }
  }
}