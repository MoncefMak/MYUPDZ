using Microsoft.EntityFrameworkCore;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Domain.Entities;
using MYUPDZ.Infrastructure.Common.Repository;
using MYUPDZ.Infrastructure.Context;

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
        var categorieResult = await _categorieRepository.AsNoTracking().AsQueryable().Where(x => x.Designation.Equals(designation)).FirstOrDefaultAsync();
        if (categorieResult != null) return true;
        return false;
    }

    public async Task<bool> AddCategorieAsync(string designation)
    {
        if (await DesignationExistAsync(designation)) return false;
        await base.AddAsync(new Categorie(designation));
        return true;
    }

    public async Task<bool> DesignationExistIdAsync(int id, string designation)
    {
        return await _categorieRepository.AsNoTracking().AnyAsync(x => x.Id != id && x.Designation == designation);
    }

    public async Task<bool> EditCategorieAsync(int id, string designation)
    {
        if (await DesignationExistIdAsync(id, designation)) return false;
        var categorie = await base.GetByIdAsync(id);
        categorie.Update(designation);
        await base.UpdateAsync(categorie);
        return true;
    }

    public async Task<bool> ArchiveCategorieAsync(int id)
    {
        var categorie = await base.GetByIdAsync(id);
        categorie.Archive();
        await base.UpdateAsync(categorie);
        return true;
    }

    #endregion

}
