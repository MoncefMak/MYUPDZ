using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MYUPDZ.Application.Common.Interfaces;
using MYUPDZ.Domain.Entities;
using MYUPDZ.Infrastructure.Identity;
using MYUPDZ.Infrastructure.Interceptors;

namespace MYUPDZ.Infrastructure.Context;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options, operationalStoreOptions)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public DbSet<Categorie> Categories { get; set; }

    public DbSet<SousCategorie> SousCategories { get; set; }

    public DbSet<Fonctionnaire> Fonctionnaires { get; set; }
}