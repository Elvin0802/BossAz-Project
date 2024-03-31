
using BossAz.Application.Interfaces;

namespace BossAz.Application.Models;

public class Admin : IRegisterable
{
	public string Email { get; set; } = "admin@gmail.com";
	public string Password { get; set; } = "Admin@123";

}
