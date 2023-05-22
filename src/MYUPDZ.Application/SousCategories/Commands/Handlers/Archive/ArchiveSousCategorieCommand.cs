using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Archive;

[Authorize(Policy = "ARCHIVE_SOUS_CATEGORIE")]
public class ArchiveSousCategorieCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
}
