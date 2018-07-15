using Microsoft.AspNetCore.Mvc;
using API_Users.Repositories;
using API_Users.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace API_Users.Controllers
{
    [Route("api/[controller]")]
    public class KeepController : Controller
    {
        private readonly KeepRepository _db;
        public KeepController(KeepRepository repo)
        {
            _db = repo;
        }
        [HttpPost]
        [Authorize]
        public Keep CreateKeep([FromBody]Keep newKeep)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                newKeep.UserId = user.Identity.Name;
                return _db.CreateKeep(newKeep);
            }
            return null;
        }
        //get all keeps
        [HttpGet]
        public IEnumerable<Keep> GetAll()
        {
            return _db.GetAll();
        }
        //get keep by id
        [HttpGet("{id}")]
        public Keep GetById(string id)
        {
            return _db.GetbyKeepId(id);
        }
        //get keep by user
        [HttpGet("user/{id}")]
        public IEnumerable<Keep> GetByUserId(string id)
        {
            return _db.GetbyUserId(id);
        }
        //edit keep
        [HttpPut("{id}")]
        [Authorize]
        public Keep EditKeep(string id, [FromBody]Keep newKeep)
        {
            return _db.EditKeep(id, newKeep);
        }
        
        [HttpDelete("{id}")]
        [Authorize]
        public string DeleteKeep(int id)
        {
            var user = HttpContext.User.Identity.Name;
            bool delete = _db.DeleteKeep(id, user);
            if(delete){
                return "Successfully Deleted User";
            }
            return "Deletion Failed";
        }

    }
}