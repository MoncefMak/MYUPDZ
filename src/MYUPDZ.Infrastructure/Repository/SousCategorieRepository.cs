using Microsoft.EntityFrameworkCore;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Domain.Entities;
using MYUPDZ.Infrastructure.Common.Repository;
using MYUPDZ.Infrastructure.Persistence;

namespace MYUPDZ.Infrastructure.Repository;

public class SousCategorieRepository : GenericRepositoryAsync<SousCategorie>, IRepositorySousCategorie
{
    #region Fields
    private readonly DbSet<SousCategorie> _sousCategorieRepository;
    #endregion

    #region Constructors
    public SousCategorieRepository(ApplicationDbContext dBContext) : base(dBContext)
    {
        _sousCategorieRepository = dBContext.Set<SousCategorie>();
    }
    #endregion

    #region Action

    public async Task<bool> DesignationExistAsync(string designation)
    {
        var categorieResult = await _sousCategorieRepository.AsNoTracking().AsQueryable().Where(x => x.Designation.Equals(designation)).FirstOrDefaultAsync();
        if (categorieResult != null) return true;
        return false;
    }

    public async Task<bool> AddSousCategorieAsync(string designation, int categorieId)
    {
        if (await DesignationExistAsync(designation)) return false;
        await base.AddAsync(new SousCategorie(designation, categorieId));
        return true;
    }

    public async Task<bool> DesignationExistIdAsync(int id, string designation)
    {
        return await _sousCategorieRepository.AsNoTracking().AnyAsync(x => x.Id != id && x.Designation == designation);
    }

    public async Task<bool> EditSousCategorieAsync(int id, string designation, int categorieId)
    {
        if (await DesignationExistIdAsync(id, designation)) return false;
        var sousCategorie = await base.GetByIdAsync(id);
        sousCategorie.Update(designation, categorieId);
        await base.UpdateAsync(sousCategorie);
        return true;
    }


    public async Task<List<SousCategorie>> GetAllAsync()
    {
        return await _sousCategorieRepository.Include(x => x.Categorie).ToListAsync();
    }

    public async Task<SousCategorie> GetSousCategorieByIdAsync(int id)
    {
        return await _sousCategorieRepository.Include(x => x.Categorie).FirstOrDefaultAsync(x => x.Id == id);
    }

}

#endregion

