using Content.Application.Common.Contracts;
using Content.Application.Common.Contracts.Repositories;
using Content.Infrastructure.DataProvider;
using Content.Infrastructure.DataProvider.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Content.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IContentDbContext, ContentDbContext>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITagRepository, TagRepository>();

        services.AddDbContext<ContentDbContext>(options =>
            options.UseNpgsql(
                configuration["DatabaseSettings:ConnectionString"]
            )
        );

        return services;
    }
}