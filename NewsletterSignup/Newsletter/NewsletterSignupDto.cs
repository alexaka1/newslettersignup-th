using System.ComponentModel.DataAnnotations;

namespace NewsletterSignup.Newsletter;

public class NewsletterSignupDto : IValidatableObject
{
    // should probably limit length as well
    // [EmailAddress]
    [Required]
    public string? Email { get; set; }

    [Required]
    public HeardAboutUs? HeardAboutUs { get; set; }

    [MaxLength(500)]
    public string? Other { get; set; }
    [MaxLength(500)]
    public string? Reason { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        int? at = Email?.IndexOf('@');

        //  RFC 5322 and 5321 allow some crazy email addresses, so syntax validation besides @ character is not a good idea
        if (at is not > 0 || !(at.Value < Email?.Length - 1))
        {
            yield return new ValidationResult("Email is invalid", new[] { nameof(Email) });
        }
        // list of valid email addresses
        // iron.man@avengers.com
        // spider-man@avengers.com
        // t'challa@avengers.com
        // rocket+groot@avengers.com
        // "Bruce 'The Hulk' Banner"@avengers.com
        // vision@[IPv6:2001:db8:1ff::a0b:dbd0]
        // "wanda@vision"@avengers   // tld is also optional if it is an intranet
    }
}
