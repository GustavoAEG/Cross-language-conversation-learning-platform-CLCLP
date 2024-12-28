namespace API;
using System.ComponentModel.DataAnnotations;

public class RegisterDto
{

[Required]
[MaxLength(100)]
public required string UserName { get; set; }

[Required]
public required string password { get; set; }

}