using Microsoft.AspNetCore.Mvc;
using API_Users.Repositories;
using API_Users.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace API_Users.Controllers
{
    [Route("api/[controller]")]
    public class VaultController : Controller
    {
        private readonly VaultRepository _db;
        public VaultController(VaultRepository repo)
        {
            _db = repo;
        }
        [HttpPost]
        [Authorize]
        public Vault CreateVault([FromBody]Vault newVault)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                newVault.UserId = user.Identity.Name;
                return _db.CreateVault(newVault);
            }
            return null;
        }
        //get all vaults
        [HttpGet]
        public IEnumerable<Vault> GetAll()
        {
            return _db.GetAll();
        }
        //get vault by id
        [HttpGet("{id}")]
        public Vault GetById(string id)
        {
            return _db.GetbyVaultId(id);
        }
        //get vault by user
        [HttpGet("user/{id}")]
        public IEnumerable<Vault> GetByUserId(string id)
        {
            return _db.GetbyUserId(id);
        }
        //edit vault
        [HttpPut("{id}")]
        public Vault EditVault(string id, [FromBody]Vault newVault)
        {
            return _db.EditVault(id, newVault);
        }
        // delete vault
        [HttpDelete("{id}")]
        [Authorize]
        public string DeleteVault(int id)
        {
            var user = HttpContext.User.Identity.Name;
            bool delete = _db.DeleteVault(id, user);
            if (delete)
            {
                return "Successfully Deleted!";
            }
            return "An Error Occurred!";
        }
    }
}
