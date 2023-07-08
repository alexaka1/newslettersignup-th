using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsletterSignup.DataAccess;
using NewsletterSignup.Web;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IWebHostEnvironment env = builder.Environment;
ConfigurationManager config = builder.Configuration;

// Add services to the container.
IServiceCollection services = builder.Services;
services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlite(config.GetConnectionString("Context"), b => { b.CommandTimeout(60); });
    if (env.IsDevelopment())
    {
        options.EnableDetailedErrors();
        options.EnableSensitiveDataLogging();
    }
});
services.AddControllersWithViews().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
        new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState))
        {
            ContentTypes =
            {
                MediaTypeNames.Application.Json,
            },
        };
});
builder.Services.AddProblemDetails();
WebApplication app = builder.Build();
ILogger logger = app.Logger;
app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            logger.LogError("Something went wrong: {ContextFeatureError}", contextFeature.Error);
            await context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error.",
            }.ToString());
        }
    });
});

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
try
{
    using IServiceScope serviceScope = app.Services.CreateScope();
    var db = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
    db.Database.Migrate();
}
catch (Exception e)
{
    // for some reason this throws an exception in docker, thus no database is created
    Console.WriteLine(e);
}

app.Run();
