﻿using MediatR;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Archive;

[Authorize(Policy = "ARCHIVE_CATEGORIE")]
public class ArchiveCategorieCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
