using System.Reflection;
using BlogPlatform.Service.Common.Behaviors;
using BlogPlatform.Service.Common.Mappings;
using Content.Application.Common.Contracts;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Content.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(assembly));
            config.AddProfile(new AssemblyMappingProfile(typeof(IContentDbContext).Assembly));
        });
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}