using FluentValidation;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Rillion.Application.Abstractions;

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