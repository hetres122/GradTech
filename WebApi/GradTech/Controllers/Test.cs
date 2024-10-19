using Microsoft.AspNetCore.Mvc;

namespace GradTech.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Test : Controller
{
    [HttpGet]
    public ActionResult<string> GetTestMessage()
    {
        return Ok("Testowa wiadomość");
    }
}