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
                INSERT INTO keeps (name, img, description, userId, public, views, shares, saves)
                VALUES (@Name, @Img, @Description, @UserId, @Public, @Views, @Shares, @Saves);
                SELECT LAST_INSERT_ID();
            ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }
    // GetAll Public Keep
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps ;");
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
    public Keep EditKeep(string id, Keep editKeep, string user)
    {
      editKeep.Id = id;
      var i = _db.Execute(@"
                UPDATE keeps SET
                    name = @Name,
                    description = @Description,
                    img = @img,
                    userId = @UserId,
                    public = @Public,
                    views = @Views,
                    shares = @Shares,
                    saves = @Saves
                WHERE id = @Id
            ", editKeep);
      if (i > 0)
      {
        return editKeep;
      }
      return null;
    }
    // Delete
    public bool DeleteKeep(int id, string userId)
    {
      var i = _db.Execute(@"
      DELETE FROM keeps
      WHERE id = @id
      AND userId = @userId
      LIMIT 1;
      ", new { id, userId });
      if (i > 0)
      {
        return true;
      }
      return false;
    }

  }





}