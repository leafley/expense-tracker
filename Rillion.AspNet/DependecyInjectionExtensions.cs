using System.Security.Claims;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Rillian.Infrastructure.Repositories;
using Rillion.Application.Abstractions;
using Rillion.Application.Validation;
using Rillion.Infrastructure;
using Rillion.Infrastructure.Repositories;

namespace Rillion.AspNet;

public static class DependecyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(Application.DependecyInjection).Assembly;

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(assembly);
            configuration.AddOpenBehavior(typeof(ValidationPipeline<,>));
        });
        services.AddValidatorsFromAssembly(assembly);
        services.AddTransient(s => new ValidationUser(
            long.TryParse(
                s.GetService<IHttpContextAccessor>()?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out var userId)
                ? userId : null));

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
        services.AddTransient<IExpenseRepository, ExpenseRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        return services;
    }
}