using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetALL(string userid, int vaultId)
    {
      string query = @"SELECT * FROM vaultkeeps vk
                        INNER JOIN keeps k on k.id = vk.keepId
                        WHERE(vaultId = @vaultId AND vk.userId = @userid)";
      return _db.Query<Keep>(query, new { userid, vaultId });
    }

    public Vault GetById(int id, string userid)
    {
      string query = @"SELECT * FROM vaults WHERE id = @id";
      Vault vault = _db.QueryFirstOrDefault<Vault>(query, new { id });
      if (vault == null) throw new Exception("Invalid Id");
      return vault;
    }

    public VaultKeep Create(VaultKeep value, string userid) //NOTE, variable names may have to be capitalized in the Keep.cs model
    {
      string query = @"
            INSERT INTO vaultkeeps (vaultId, keepId, userId)
                    VALUES (@vaultId, @keepId, @userid);
                    SELECT LAST_INSERT_ID();
            ";
      value.userId = userid;
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

    public string DeleteVault(VaultKeep value)
    {
      string query = @"
                        DELETE FROM vaultkeeps WHERE id = @id AND vaultId = @vaultId AND userId = @userId";
      int changedRows = _db.Execute(query, new { value.id, value.vaultId, value.userId });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted Vault";

    }
  }
}