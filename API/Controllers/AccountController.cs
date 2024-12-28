using System.Security.Cryptography;
using System.Text;
using API.Entities;
using API.Data;
using API.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController(DataContext context) : BaseAPIController
{

    [HttpPost("register")] //account/register

    public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
    {

        if (await UserExists(registerDto.UserName)) return BadRequest("Usuário já existe");


        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            UserName = registerDto.UserName.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password)),
            PasswordSalta = hmac.Key
        };
        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }

    private async Task<bool> UserExists(string username)
    {
        return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }

}