using MYUPDZ.Domain.Entities;

namespace MYUPDZ.Application.Common.Interfaces.Repository;

public interface IRepositoryCategorie : IGenericRepositoryAsync<Categorie>
{
    Task<List<Categorie>> GetAllAsync();
    Task<bool> AddCategorieAsync(string designation);
    Task<bool> EditCategorieAsync(int id, string designation);
    Task<bool> ArchiveCategorieAsync(int id);
}
