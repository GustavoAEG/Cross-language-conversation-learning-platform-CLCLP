using Microsoft.AspNetCore.Mvc;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using API.Data; // Adicione esta linha se a classe DataContext estiver nesse namespace


namespace API;  

public class UsersController(DataContext context) : BaseAPIController
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            return Ok(users); // HTTP 200.
        }

        [HttpGet("{id:int}")] // api/users/{id}
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null) return NotFound(); // 404 se o usuário não for encontrado

            return Ok(user); // Retorna o usuário encontrado
        }
    }

