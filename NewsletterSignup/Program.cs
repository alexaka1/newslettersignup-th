using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsletterSignup.DataAccess;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IWebHostEnvironment env = builder.Environment;
ConfigurationManager config = builder.Configuration;

// Add services to the container.
IServiceCollection services = builder.Services;
services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("Context"), b => { b.CommandTimeout(60); });
    if (env.IsDevelopment())
    {
        options.EnableDetailedErrors();
        options.EnableSensitiveDataLogging();
    }
});
services.AddControllersWithViews().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
        new BadRequestObjectResult(context.ModelState)
        {
            ContentTypes =
            {
                MediaTypeNames.Application.Json,
            },
        };
});
builder.Services.AddProblemDetails();
WebApplication app = builder.Build();
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
