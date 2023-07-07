using System.ComponentModel.DataAnnotations;

namespace NewsletterSignup.Newsletter;

public class NewsletterSignupDto:IValidatableObject
{
    // should probably limit length as well
    // [EmailAddress]
    [Required]
    public string? Email { get; set; }
    [Required]
    public HeardAboutUs? HeardAboutUs { get; set; }
    [MaxLength(500)]
    public string? Other { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var at = Email?.IndexOf('@');
        //  RFC 5322 and 5321 allow some crazy email addresses, so syntax validation besides @ character is not a good idea
        // email can actually contain more than one @
        if (at is > 0 && at.Value != Email?.Length - 1 /*&& at.Value == Email.LastIndexOf('@')*/)
        {
            yield return new ValidationResult("Email address cannot start with @", new[] { nameof(Email) });
        }
    }
}
