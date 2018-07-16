using System;
using System.Collections.Generic;
using System.Data;
using API_Users.Models;
using Dapper;

namespace API_Users.Repositories
{
    public class VaultKeepRepository : DbContext
    {
        public VaultKeepRepository(IDbConnection db) : base(db)
        {

        }

        // create vaultkeep
        public VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
        {
            int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaultskeeps (userId, keepId, vaultId)
                VALUES (@UserId, @KeepId, @VaultId);
                SELECT LAST_INSERT_ID();
            ", newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }
        // GetbyUserId
        public IEnumerable<VaultKeep> GetbyUserId(string id)
        {
            return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps WHERE userId = @userId;", new { id });
        }
        // Edit
        public VaultKeep EditVaultKeep(int id, VaultKeep vaultKeep)
        {
            vaultKeep.Id = id;
            var i = _db.Execute(@"
                UPDATE vaultkeep SET
                    userid = @UserId,
                    keepId = @KeepId
                WHERE vaultId = @VaultId
            ", vaultKeep);
            if (i > 0)
            {
                return vaultKeep;
            }
            return null;
        }
        // Delete
        public bool DeleteVaultKeep(int id)
        {
            var i = _db.Execute(@"
      DELETE FROM vaultkeeps
      WHERE id = @id;
      ", new { id});
            if (i > 0)
            {
                return true;
            }
            return false;
        }

    }
}

