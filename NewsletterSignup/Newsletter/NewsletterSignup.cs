namespace NewsletterSignup.Newsletter;

public class NewsletterSignup
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public HeardAboutUs HeardAboutUs { get; set; }
    public string? Other { get; set; }
    public string? Reason { get; set; }
}
