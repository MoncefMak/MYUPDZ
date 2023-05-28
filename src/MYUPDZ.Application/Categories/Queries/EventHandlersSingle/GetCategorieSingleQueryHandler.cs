using AutoMapper;
using MediatR;
using MYUPDZ.Application.Common.Exceptions;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Categories.Queries.EventHandlersSingle;

public class GetCategorieSingleQueryHandler : IRequestHandler<GetCategorieSingleQuery, CategorieDto>
{
    #region Fields
    private readonly IRepositoryCategorie _repositoryCategorie;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCategorieSingleQueryHandler(IRepositoryCategorie repository, IMapper mapper)
    {
        _repositoryCategorie = repository;
        _mapper = mapper;
    }
    #endregion

    #region Handle functions
    public async Task<CategorieDto> Handle(GetCategorieSingleQuery request, CancellationToken cancellationToken)
    {
        var categorie = await _repositoryCategorie.GetByIdAsync(request.Id);
        if (categorie == null) throw new NotFoundException("Category not found.");
        return _mapper.Map<CategorieDto>(categorie);
    }
    #endregion

}
