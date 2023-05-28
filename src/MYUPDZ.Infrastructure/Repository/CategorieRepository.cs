using Microsoft.EntityFrameworkCore;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Domain.Entities;
using MYUPDZ.Infrastructure.Common.Repository;
using MYUPDZ.Infrastructure.Persistence;

namespace MYUPDZ.Infrastructure.Repository;

public class CategorieRepository : GenericRepositoryAsync<Categorie>, IRepositoryCategorie
{
    #region Fields
    private readonly DbSet<Categorie> _categorieRepository;
    #endregion

    #region Constructors
    public CategorieRepository(ApplicationDbContext dBContext) : base(dBContext)
    {
        _categorieRepository = dBContext.Set<Categorie>();
    }
    #endregion

    #region Action
    public async Task<List<Categorie>> GetAllAsync()
    {
        return await _categorieRepository.ToListAsync();
    }

    public async Task<bool> DesignationExistAsync(string designation)
    {
        return !(await _categorieRepository.AsNoTracking().FirstOrDefaultAsync(x => x.Designation.Equals(designation)) != null);
    }

    public async Task<int> AddCategorie(string designation)
    {
        var entity = new Categorie(designation);
        await AddAsync(entity);
        return entity.Id;
    }

    public async Task<bool> DesignationExistIdAsync(int id, string designation)
    {
        return await _categorieRepository.AsNoTracking().AnyAsync(x => x.Id != id && x.Designation == designation);
    }

    public async Task EditCategorieAsync(int id, string designation)
    {
        var categorie = await GetByIdAsync(id);
        categorie.Update(designation);
        await UpdateAsync(categorie);
    }

    public async Task ArchiveCategorieAsync(int id)
    {
        var categorie = await GetByIdAsync(id);
        categorie.Archive();
        await UpdateAsync(categorie);
    }
    #endregion

}
