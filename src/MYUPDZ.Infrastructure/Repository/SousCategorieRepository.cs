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
        return !(await _sousCategorieRepository.AsNoTracking().FirstOrDefaultAsync(x => x.Designation.Equals(designation)) != null);
    }

    public async Task<int> AddSousCategorieAsync(string designation, int categorieId)
    {
        var entity = new SousCategorie(designation, categorieId);
        await AddAsync(entity);
        return entity.Id;
    }

    public async Task<bool> DesignationExistIdAsync(int id, string designation)
    {
        return await _sousCategorieRepository.AsNoTracking().AnyAsync(x => x.Id != id && x.Designation == designation);
    }

    public async Task EditSousCategorieAsync(int id, string designation, int categorieId)
    {
        var sousCategorie = await GetByIdAsync(id);
        sousCategorie.Update(designation, categorieId);
        await UpdateAsync(sousCategorie);
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

