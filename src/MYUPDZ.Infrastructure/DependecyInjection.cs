using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MYUPDZ.Application.Common.Interfaces;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Domain.Enums;
using MYUPDZ.Infrastructure.Common.Repository;
using MYUPDZ.Infrastructure.Context;
using MYUPDZ.Infrastructure.Identity;
using MYUPDZ.Infrastructure.Interceptors;
using MYUPDZ.Infrastructure.Option;
using MYUPDZ.Infrastructure.Persistance;
using MYUPDZ.Infrastructure.Repository;
using MYUPDZ.Infrastructure.Services;
using System.Text;

namespace MYUPDZ.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure database context
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DatabaseInitializer>();

            // Register repositories
            services.AddTransient<IRepositoryCategorie, CategorieRepository>();
            services.AddTransient<IRepositorySousCategorie, SousCategorieRepository>();
            services.AddTransient<IRepositoryFonctionnaire, FonctionnaireRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            // Configure identity
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Configure password options
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                // Configure unique email requirement
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<SignInManager<ApplicationUser>>();

            // Register custom services
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            // Configure JWT authentication
            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SigningKey)),
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidateAudience = true,
                        ValidAudiences = jwtSettings.Audiences,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            // Configure authorization policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));

                foreach (string permission in new Permission())
                {
                    options.AddPolicy(permission, policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.RequireClaim("permission", permission);
                    });
                }
            });

            return services;
        }
    }
}
