using Content.API.Middleware;
using Content.Application;
using Content.Infrastructure;
using Content.Infrastructure.DataProvider;
using Microsoft.EntityFrameworkCore;

namespace Content.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<ContentDbContext>();
                context.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Content.API v1");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseCors(options =>
        {
            options.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
        app.UseStaticFiles();
        app.UseAuthorization();
        app.MapControllers();
        app.UseCustomExceptionHandler();
        app.Run();
    }
}