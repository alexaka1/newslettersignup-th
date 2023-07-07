using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsletterSignup.DataAccess;
using NewsletterSignup.Newsletter;

namespace NewsletterSignup.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsletterController : ControllerBase
{
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(NewsletterSignupDto signup, [FromServices] ApplicationContext db, CancellationToken cancellationToken)
    {
        var model = new Newsletter.NewsletterSignup
        {
            // MVC handled validation, so we can assume the values are valid
            HeardAboutUs = signup.HeardAboutUs.GetValueOrDefault(),
            Email = signup.Email ?? "",
            Other = signup.Other,
        };
        if (await db.NewsletterSignups.AnyAsync(x => x.Email == model.Email, cancellationToken))
        {
            ModelState.AddModelError(nameof(model.Email), "Email already signed up");
            return ValidationProblem(ModelState);
        }
        db.NewsletterSignups.Add(model);
        await db.SaveChangesAsync(cancellationToken);

        // after signing up, we could send a verification email to actually validate it is a real email and if verification expires, we can delete the signup
        return Ok();
    }
}
