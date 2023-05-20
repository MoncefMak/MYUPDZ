using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependecyInjection).Assembly;

        //MediatR Configue
        services.AddMediatR(cnf => cnf.RegisterServicesFromAssembly(assembly));
        //AutoMapper Configue
        services.AddAutoMapper(assembly);
        //Validators
        services.AddValidatorsFromAssembly(assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}
