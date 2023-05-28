using MYUPDZ.Domain.Entities;

namespace MYUPDZ.Application.Common.Interfaces.Repository;

public interface IRepositorySousCategorie : IGenericRepositoryAsync<SousCategorie>
{
    Task<List<SousCategorie>> GetAllAsync();
    Task<int> AddSousCategorieAsync(string designation, int categorieId);
    Task EditSousCategorieAsync(int id, string designation, int categorieId);
    Task<bool> DesignationExistAsync(string designation);
}
