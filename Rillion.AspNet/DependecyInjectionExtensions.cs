using FluentValidation;

public static class DependecyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(Rillion.Application.DependecyInjection).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(assembly));
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}