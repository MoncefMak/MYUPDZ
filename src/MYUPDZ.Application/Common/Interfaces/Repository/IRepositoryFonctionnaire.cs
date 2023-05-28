using MYUPDZ.Domain.Entities;

namespace MYUPDZ.Application.Common.Interfaces.Repository;

public interface IRepositoryFonctionnaire : IGenericRepositoryAsync<Fonctionnaire>
{
    Task<List<Fonctionnaire>> GetAllAsync();
    Task<int> AddFonctionnaireAsync(string nom, string prenom, string email, string password, string matricule, DateTime dateEmbauche, decimal salaire);
    Task EditFonctionnaireAsync(int id, string nom, string prenom, string email, string password, string matricule, DateTime dateEmbauche, decimal salaire);
    Task ArchiveFonctionnaireAsync(int id);
}
