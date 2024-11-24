using System.Security.Claims;
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
    
    [HttpGet("roles")]
    public IActionResult GetUserRoles()
    {
        var roles = User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList();
        return Ok(roles);
    }
}