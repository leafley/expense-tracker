using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Rillian.Infrastructure.Repositories;
using Rillion.Application.Abstractions;
using Rillion.Infrastructure;
using Rillion.Infrastructure.Repositories;

namespace Rillion.AspNet;

public static class DependecyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(Rillion.Application.DependecyInjection).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(assembly));
        services.AddValidatorsFromAssembly(assembly);

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