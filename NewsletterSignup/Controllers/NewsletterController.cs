using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NewsletterSignup.Newsletter;

namespace NewsletterSignup.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsletterController: ControllerBase
{
    [HttpPost("signup")]
    public IActionResult SignUp(NewsletterSignupDto signup)
    {
        return Ok();
    }
}
