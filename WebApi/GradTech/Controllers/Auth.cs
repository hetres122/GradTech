using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GradTech.Controllers;

[ApiController]
public class Auth(SignInManager<IdentityUser> signInManager) : Controller
{
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] object? empty)
    {
        if (empty != null)
        {
            await signInManager.SignOutAsync();
            return Ok();
        }
        return Unauthorized();
    }
    
    [HttpGet]
    [Route("check-auth")]
    public IActionResult CheckAuth()
    {
        if (User.Identity.IsAuthenticated)
        {
            return Ok(new { isAuthenticated = true });
        }
        return Unauthorized();
    }
}