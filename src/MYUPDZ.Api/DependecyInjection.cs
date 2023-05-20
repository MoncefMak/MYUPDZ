using MYUPDZ.Api.Services;
using MYUPDZ.Application.Common.Interfaces;
using MYUPDZ.Infrastructure.Context;

namespace MYUPDZ.Api;

public static class DependecyInjection
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddHttpContextAccessor();

        services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();

        return services;
    }
}