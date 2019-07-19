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

    public Keep Create(Keep value)
    {
      string query = @"
            INSERT INTO keeps (name, price)
                    VALUES (@Name, @Price);
                    SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public Flower Update(Flower value)
    {
      string query = @"
            UPDATE flowers
            SET
                name = @Name,
                price = @Price
            WHERE id = @Id;            
            SELECT * FROM flowers WHERE id = @Id";
      return _db.QueryFirstOrDefault<Flower>(query, value);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM flowers WHERE id = @Id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted Flower";

    }
  }
}