using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace NewsletterSignup.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsletterController: ControllerBase
{
    [HttpGet("test")]
    [Produces(MediaTypeNames.Text.Plain)]
    public IActionResult Test()
    {
        return new JsonResult(new {text = "Testing"});
    }
}
