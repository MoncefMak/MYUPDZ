using MYUPDZ.Domain.Entities;

namespace MYUPDZ.Application.Common.Interfaces.Repository;

public interface IRepositoryFonctionnaire : IGenericRepositoryAsync<Fonctionnaire>
{
    Task<List<Fonctionnaire>> GetAllAsync();
    Task<bool> AddFonctionnaireAsync(string nom, string prenom, string email, string password, string matricule, DateTime dateEmbauche, decimal salaire);
    Task<bool> EditFonctionnaireAsync(int id, string nom, string prenom, string email, string password, string matricule, DateTime dateEmbauche, decimal salaire);
    Task<bool> ArchiveFonctionnaireAsync(int id);
}
