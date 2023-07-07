using Microsoft.EntityFrameworkCore;

namespace NewsletterSignup.DataAccess;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

/*
dotnet ef migrations add Initial -p NewsletterSignup
dotnet ef database update -p NewsletterSignup
*/
    public DbSet<Newsletter.NewsletterSignup> NewsletterSignups => Set<Newsletter.NewsletterSignup>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Newsletter.NewsletterSignup>(b =>
        {
            b.ToTable("NewsletterSignup");
            b.HasKey(x => x.Id);
            b.Property(x => x.Email).HasMaxLength(450).IsRequired();
            b.HasIndex(x => x.Email).IsUnique();
            b.Property(x => x.HeardAboutUs).HasConversion<string>();
            b.Property(x => x.Other).HasMaxLength(500);
            b.Property(x => x.Reason).HasMaxLength(500);
        });
    }
}
