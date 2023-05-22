using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MYUPDZ.Domain.Enums;
using MYUPDZ.Infrastructure.Identity;
using MYUPDZ.Infrastructure.Persistence;
using System.Security.Claims;

namespace MYUPDZ.Infrastructure.Persistance;

public class DatabaseInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;


    public DatabaseInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            // Handle the exception as needed
            throw new Exception("An error occurred while initializing the database.", ex);
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        IdentityRole administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        ApplicationUser administrator = new ApplicationUser
        {
            UserName = "administrator@myupdz",
            Email = "administrator@myupdz",
            LockoutEnabled = false // Set LockoutEnabled property to false
        };

        var userExists = _userManager.Users.Any(u => u.UserName == administrator.UserName);

        if (!userExists)
        {
            var createUserResult = await _userManager.CreateAsync(administrator, "Administrator1!");

            if (createUserResult.Succeeded)
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });

                await AddPermissionsToUser(administrator);
            }
        }
        else
        {
            var existingAdministrator = await _userManager.FindByNameAsync(administrator.UserName);
            await AddPermissionsToUser(existingAdministrator);
        }
    }

    private async Task AddPermissionsToUser(ApplicationUser user)
    {
        foreach (string permission in new Permission())
        {
            var existingClaims = await _userManager.GetClaimsAsync(user);
            if (!existingClaims.Any(c => c.Type == "permission" && c.Value == permission))
            {
                await _userManager.AddClaimAsync(user, new Claim("permission", permission));
            }
        }
    }

}

