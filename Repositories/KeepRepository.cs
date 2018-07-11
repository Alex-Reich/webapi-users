using System.Collections.Generic;
using System.Data;
using API_Users.Models;
using Dapper;

namespace API_Users.Repositories
{
  public class KeepRepository : DbContext
  {
    public KeepRepository(IDbConnection db) : base(db)
    {

    }
    // Create Keep
    public Keep CreateKeep(Keep newKeep)
    {
      string id = _db.ExecuteScalar<string>(@"
                INSERT INTO keeps (name, description, userId)
                VALUES (@Name, @Description, @UserId);
                SELECT LAST_INSERT_ID();
            ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }
    // GetAll Public Keep
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE public = true;");
    }
    // GetbyUser
    public IEnumerable<Keep> GetbyUserId(string id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @id;", new { id });
    }
    // GetbyId
    public Keep GetbyKeepId(string id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @id;", new { id });
    }
    // Edit
    public Keep EditKeep(string id, Keep keep)
    {
      keep.Id = id;
      var i = _db.Execute(@"
                UPDATE keeps SET
                    title = @Title,
                    body = @Body
                WHERE id = @Id
            ", keep);
      if (i > 0)
      {
        return keep;
      }
      return null;
    }
    // Delete
    public bool DeleteKeep(string id)
    {
      var i = _db.Execute(@"
      DELETE FROM keeps
      WHERE id = @id
      LIMIT 1;
      ", new { id });
      if (i > 0)
      {
        return true;
      }
      return false;
    }

  }





}