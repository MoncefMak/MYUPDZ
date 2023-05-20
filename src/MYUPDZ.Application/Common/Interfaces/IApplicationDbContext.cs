using Microsoft.EntityFrameworkCore;
using MYUPDZ.Domain.Entities;

namespace MYUPDZ.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Categorie> Categories { get; }
    DbSet<SousCategorie> SousCategories { get; }
    DbSet<Fonctionnaire> Fonctionnaires { get; }


}