using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> GetALL(string userid)
    {
      string query = "SELECT * FROM vaults where userId = @userid";
      return _db.Query<Vault>(query, new { userid });
    }

    public Vault GetById(int id, string userid)
    {
      string query = @"SELECT * FROM vaults WHERE id = @id";
      Vault vault = _db.QueryFirstOrDefault<Vault>(query, new { id });
      if (vault == null) throw new Exception("Invalid Id");
      return vault;
    }

    // public Keep GetById(int id)
    // {
    //   string query = @"SELECT * FROM keeps WHERE id = @id";
    //   Keep keep = _db.QueryFirstOrDefault<Keep>(query, new { id });
    //   if (keep == null) throw new Exception("Invalid Id");
    //   return keep;
    // }

    // public IEnumerable<Vault> GetVaultsFromCurrentUser(string id)
    // {
    //   string query = @"SELECT * FROM vaults WHERE userid = @id";
    //   return _db.Query<Vault>(query, new { id });
    // }
    public Vault Create(Vault value) //NOTE, variable names may have to be capitalized in the Keep.cs model
    {
      string query = @"
            INSERT INTO vaults (name, description, userId)
                    VALUES (@name, @description, @userid);
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
                isPrivate = @isPrivate
            WHERE id = @id;            
            SELECT * FROM keeps WHERE id = @id";

      return _db.QueryFirstOrDefault<Keep>(query, value);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM vaults WHERE id = @id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted Vault";

    }
  }
}