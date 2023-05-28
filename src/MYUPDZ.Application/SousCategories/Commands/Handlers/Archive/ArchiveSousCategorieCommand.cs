using MediatR;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Archive;

[Authorize(Policy = "ARCHIVE_SOUS_CATEGORIE")]
public class ArchiveSousCategorieCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
