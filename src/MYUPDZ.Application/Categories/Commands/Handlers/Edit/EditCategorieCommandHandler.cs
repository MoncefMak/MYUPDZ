using MediatR;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Edit;

public class EditCategoryCommandHandler : IRequestHandler<EditCategorieCommand, Unit>
{
    private readonly IRepositoryCategorie _repositoryCategory;

    public EditCategoryCommandHandler(IRepositoryCategorie repositoryCategory)
    {
        _repositoryCategory = repositoryCategory;
    }

    public async Task<Unit> Handle(EditCategorieCommand request, CancellationToken cancellationToken)
    {
        await _repositoryCategory.EditCategorieAsync(request.Id, request.Designation);
        return Unit.Value; // Return success response or appropriate response object
    }

}