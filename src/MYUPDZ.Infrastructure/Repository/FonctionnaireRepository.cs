using Microsoft.EntityFrameworkCore;
using MYUPDZ.Application.Common.Interfaces;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Domain.Entities;
using MYUPDZ.Infrastructure.Common.Repository;
using MYUPDZ.Infrastructure.Persistence;

namespace MYUPDZ.Infrastructure.Repository;

public class FonctionnaireRepository : GenericRepositoryAsync<Fonctionnaire>, IRepositoryFonctionnaire
{
    #region Fields
    private readonly DbSet<Fonctionnaire> _fonctionnaireRepository;
    private readonly IIdentityService _identityService;
    #endregion

    #region Constructors
    public FonctionnaireRepository(ApplicationDbContext dBContext, IIdentityService identityService) : base(dBContext)
    {
        _fonctionnaireRepository = dBContext.Set<Fonctionnaire>();
        _identityService = identityService;
    }
    #endregion

    #region Action
    public async Task<List<Fonctionnaire>> GetAllAsync()
    {
        return await _fonctionnaireRepository.ToListAsync();
    }
    public async Task<bool> MatriculeExistsAsync(string matricule)
    {
        return await _fonctionnaireRepository.AsNoTracking().AnyAsync(x => x.Matricule == matricule);
    }
    public async Task<int> AddFonctionnaireAsync(string nom, string prenom, string email, string password, string matricule, DateTime dateEmbauche, decimal salaire)
    {
        using (var transaction = BeginTransaction())
        {
            try
            {
                matricule = string.IsNullOrEmpty(matricule) ? DateTime.UtcNow.Ticks.ToString() : matricule;

                // Check if matricule already exists inside the transaction
                if (await MatriculeExistsAsync(matricule))
                {
                    throw new Exception("Matricule already exists."); // Or handle the duplicate matricule case differently
                }

                string userId = null;

                if (!string.IsNullOrEmpty(password))
                {
                    // Create a new user.
                    var (result, id) = await _identityService.CreateUserAsync(matricule, email, password);
                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to create user.");
                    }
                    userId = id;
                }

                // Create a new fonctionnaire.
                var fonctionnaire = new Fonctionnaire(nom, prenom, matricule, email, dateEmbauche, salaire);

                if (!string.IsNullOrEmpty(userId))
                {
                    fonctionnaire.AssignUser(userId);
                }

                await AddAsync(fonctionnaire);

                Commit();

                return fonctionnaire.Id;
            }
            catch (Exception ex)
            {
                // Rollback the transaction in case of an error.
                RollBack();
                throw; // Re-throw the exception to propagate it
            }
        }
    }
    public async Task EditFonctionnaireAsync(int id, string nom, string prenom, string email, string password, string matricule, DateTime dateEmbauche, decimal salaire)
    {
        using (var transaction = BeginTransaction())
        {
            try
            {
                if (await MatriculeExistIdAsync(id, matricule))
                {
                    throw new Exception("Duplicate matricule"); // Throw an exception for duplicate matricule case
                }

                var fonctionnaire = await GetByIdAsync(id);

                if (fonctionnaire.HasUser && email != null && password != null)
                {
                    await _identityService.UpdateUserAsync(fonctionnaire.User, matricule, email, password);
                }
                else if (!fonctionnaire.HasUser && email != null && password != null)
                {
                    var (result, userId) = await _identityService.CreateUserAsync(matricule, email, password);
                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to create user.");
                    }
                    fonctionnaire.AssignUser(userId);
                }

                fonctionnaire.Update(nom, prenom, matricule, email, dateEmbauche, salaire);
                await UpdateAsync(fonctionnaire);

                Commit();
            }
            catch (Exception ex)
            {
                RollBack();
                throw; // Re-throw the exception to propagate it
            }
        }
    }
    public async Task<bool> MatriculeExistIdAsync(int id, string matricule)
    {
        return await _fonctionnaireRepository.AsNoTracking().AnyAsync(x => x.Id != id && x.Matricule == matricule);
    }
    public async Task ArchiveFonctionnaireAsync(int id)
    {
        using (var transaction = BeginTransaction())
        {
            try
            {
                var fonctionnaire = await GetByIdAsync(id);

                if (fonctionnaire.User != null)
                {
                    await _identityService.BlockUserAsync(fonctionnaire.User);
                }

                fonctionnaire.Archive();
                await base.UpdateAsync(fonctionnaire);

                // Save the changes to the database
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                // Roll back all the changes made to the database
                await transaction.RollbackAsync();
                throw; // Re-throw the exception to propagate it
            }
        }
    }

    #endregion

}
