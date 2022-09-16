using System.ComponentModel.DataAnnotations;

namespace ChuckSwapiCSharp.Domain.DTOs;

public class LogoutDto
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Token { get; set; }
}


public class LoginDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}