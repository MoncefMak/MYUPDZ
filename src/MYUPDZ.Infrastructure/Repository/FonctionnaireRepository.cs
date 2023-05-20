using Microsoft.EntityFrameworkCore;
using MYUPDZ.Application.Common.Interfaces;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Domain.Entities;
using MYUPDZ.Infrastructure.Common.Repository;
using MYUPDZ.Infrastructure.Context;

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

    public async Task<bool> MatriculeExistAsync(string matricule)
    {
        var fonctionnaireResult = await _fonctionnaireRepository.AsNoTracking().AsQueryable().Where(x => x.Matricule.Equals(matricule)).FirstOrDefaultAsync();
        if (fonctionnaireResult != null) return true;
        return false;
    }

    public async Task<bool> AddFonctionnaireAsync(string nom, string prenom, string email, string password, string matricule, DateTime dateEmbauche, decimal salaire)
    {
        using (var transaction = BeginTransaction())
        {
            try
            {
                matricule = string.IsNullOrEmpty(matricule) ? DateTime.UtcNow.Ticks.ToString() : matricule;

                // Check if matricule already exists inside the transaction
                if (await MatriculeExistAsync(matricule)) return false;

                string userId = null;

                if (!string.IsNullOrEmpty(password))
                {
                    // Créer un nouvel utilisateur.
                    var (result, id) = await _identityService.CreateUserAsync(matricule, email, password);
                    if (!result.Succeeded) throw new Exception("Failed to create user.");
                    userId = id;
                }

                // Créer un nouveau fonctionnaire.
                await AddAsync(new Fonctionnaire(nom, prenom, matricule, email, dateEmbauche, salaire, userId));

                Commit();

                return true;
            }
            catch (Exception ex)
            {
                // Annulez la transaction en cas d'erreur.
                RollBack();
                return false;
            }
        }
    }


    public async Task<bool> MatriculeExistIdAsync(int id, string matricule)
    {
        return await _fonctionnaireRepository.AsNoTracking().AnyAsync(x => x.Id != id && x.Matricule == matricule);
    }

    public async Task<bool> EditFonctionnaireAsync(int id, string nom, string prenom, string email, string password, string matricule, DateTime dateEmbauche, decimal salaire)
    {
        using (var transaction = BeginTransaction())
        {
            try
            {
                if (await MatriculeExistIdAsync(id, matricule))
                {
                    return false;
                }

                var fonctionnaire = await GetByIdAsync(id);

                if (fonctionnaire.User != null)
                {
                    if (email != null && password != null)
                    {
                        await _identityService.UpdateUserAsync(fonctionnaire.User, matricule, email, password);
                    }
                }
                else
                {
                    if (email != null && password != null)
                    {
                        var (result, userId) = await _identityService.CreateUserAsync(matricule, email, password);
                        if (!result.Succeeded)
                        {
                            throw new Exception("Failed to create user.");
                        }
                        fonctionnaire.UpdateWithUser(nom, prenom, matricule, email, dateEmbauche, salaire, userId);
                    }
                }

                fonctionnaire.UpdateWithoutUser(nom, prenom, matricule, email, dateEmbauche, salaire);
                await UpdateAsync(fonctionnaire);
                Commit();
                return true;
            }
            catch (Exception ex)
            {
                RollBack();
                return false;
            }
        }
    }

    public async Task<bool> ArchiveFonctionnaireAsync(int id)
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
                // Enregistrer les modifications dans la base de données
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Annuler toutes les modifications apportées à la base de données
                await transaction.RollbackAsync();
                return false;
            }
        }
    }

    #endregion

}
