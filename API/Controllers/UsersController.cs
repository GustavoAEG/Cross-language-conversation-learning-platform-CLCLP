using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Data;

namespace API
{
    [ApiController]
    [Route("api/[controller]")] // API/USERS
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users); // Envolvemos em "Ok" para retornar um status HTTP 200.
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id) // Ajustei o nome do método para GetUser.
        {
            var user = _context.Users.Find(id);

            if (user == null) return NotFound(); // Corrigido: "NotFound()" em vez de "Not Found".

            return Ok(user);
        }
    }
}
