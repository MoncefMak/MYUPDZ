using AutoMapper;
using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.SousCategories.Queries.EventHandlersSingle;

public class GetSousCategorieSingleQueryHandler : ResponseHandler, IRequestHandler<GetSousCategorieSingleQuery, Response<SousCategorieDto>>
{
    #region Fields
    private readonly IRepositorySousCategorie _repository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetSousCategorieSingleQueryHandler(IRepositorySousCategorie repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    #endregion

    #region Handle functions
    public async Task<Response<SousCategorieDto>> Handle(GetSousCategorieSingleQuery request, CancellationToken cancellationToken)
    {
        var categorie = await _repository.GetByIdAsync(request.Id);
        if (categorie == null) return NotFound<SousCategorieDto>("Object");
        var categorieMapper = _mapper.Map<SousCategorieDto>(categorie);
        return Success(categorieMapper);
    }
    #endregion

}
