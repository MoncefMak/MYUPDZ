using MYUPDZ.Domain.Entities;

namespace MYUPDZ.Application.Common.Interfaces.Repository;

public interface IRepositoryCategorie : IGenericRepositoryAsync<Categorie>
{
    Task<List<Categorie>> GetAllAsync();
    Task<int> AddCategorie(string designation);
    Task<bool> DesignationExistAsync(string designation);
    Task EditCategorieAsync(int id, string designation);
    Task<bool> DesignationExistIdAsync(int id, string designation);
    Task ArchiveCategorieAsync(int id);
}
