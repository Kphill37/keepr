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
      string query = "SELECT * FROM keeps WHERE id = @id";
      Keep newKeep = _db.QueryFirstOrDefault<Keep>(query, new { id });
      if (newKeep == null) throw new Exception("Invalid Id");
      return newKeep;
    }

    public IEnumerable<Keep> GetKeepsFromCurrentUser(string userid)
    {
      string query = @"SELECT * FROM keeps where userid = @userid";
      return _db.Query<Keep>(query, new { userid });
    }
    public Keep Create(Keep value) //NOTE, variable names may have to be capitalized in the Keep.cs model
    {
      string query = @"
            INSERT INTO keeps (name, description, userId, img, isPrivate, views, shares, keeps)
                    VALUES (@name, @description, @userid, @img, @isPrivate, @views, @shares, @keeps);
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
                userId = @userid,
                img = @img,
                isPrivate = @isPrivate,
                views = @views,
                shares = @shares,
                keeps = @keeps
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