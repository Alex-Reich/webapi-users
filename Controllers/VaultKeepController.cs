using Microsoft.AspNetCore.Mvc;
using API_Users.Repositories;
using API_Users.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace API_Users.Controllers
{
    [Route("api/[controller]")]
    public class VaultKeepController : Controller
    {
        private readonly VaultKeepRepository _db;
        public VaultKeepController(VaultKeepRepository repo)
        {
            _db = repo;
        }
        [HttpPost]
        [Authorize]
        public VaultKeep CreateVaultKeep([FromBody]VaultKeep newVaultKeep)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                newVaultKeep.UserId = user.Identity.Name;
                return _db.CreateVaultKeep(newVaultKeep);
            }
            return null;
        }
        //get vault by user
        [HttpGet("{userId}")]
        public IEnumerable<VaultKeep> GetAllByUserId(string userId)
        {
            return _db.GetbyUserId(userId);
        }
        //edit vault
        [HttpPut("{id}")]
        public VaultKeep EditVaultKeep(int id, [FromBody]VaultKeep newVaultKeep)
        {
            return _db.EditVaultKeep(id, newVaultKeep);
        }
        // delete vault
        [HttpDelete("{id}")]
        [Authorize]
        public string DeleteVaultKeep(int id)
        {
            var user = HttpContext.User.Identity.Name;
            bool delete = _db.DeleteVaultKeep(id);
            if (delete)
            {
                return "Successfully Deleted!";
            }
            return "An Error Occurred!";
        }
    }
}
