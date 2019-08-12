using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetALL()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }

    public Keep GetById(int id)
    {
      string query = @"SELECT * FROM keeps WHERE id = @id";
      Keep keep = _db.QueryFirstOrDefault<Keep>(query, new { id });
      if (keep == null) throw new Exception("Invalid Id");
      return keep;
    }

    public IEnumerable<Keep> GetKeepsFromCurrentUser(string id)
    {
      string query = @"SELECT * FROM keeps WHERE userid = @id";
      return _db.Query<Keep>(query, new { id });
    }
    public Keep Create(Keep value) //NOTE, variable names may have to be capitalized in the Keep.cs model
    {
      string query = @"
            INSERT INTO keeps (name, description, userId, img, isPrivate)
                    VALUES (@name, @description, @userid, @img, @isPrivate);
                    SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(query, value);
      value.id = id;
      return value;
    }


    public Keep Update(Keep value)
    {
      string query = @"
            UPDATE keeps
            SET
                name = @name,
                description = @description,
                img = @img,
                isPrivate = @isPrivate,
                views = @views,
                keeps = @keeps,
                shares = @shares
            WHERE id = @id;            
            SELECT * FROM keeps WHERE id = @id";

      return _db.QueryFirstOrDefault<Keep>(query, value);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM keeps WHERE id = @id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted Keep";
    }
  }
}