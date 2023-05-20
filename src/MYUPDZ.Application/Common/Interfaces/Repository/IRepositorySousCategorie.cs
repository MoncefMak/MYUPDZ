using MYUPDZ.Domain.Entities;

namespace MYUPDZ.Application.Common.Interfaces.Repository;

public interface IRepositorySousCategorie : IGenericRepositoryAsync<SousCategorie>
{
    Task<List<SousCategorie>> GetAllAsync();
    Task<bool> AddSousCategorieAsync(string designation, int categorieId);
    Task<bool> EditSousCategorieAsync(int id, string designation, int categorieId);

}
