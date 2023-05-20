using AutoMapper;
using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.SousCategories.Queries.EventHandlers;

public class GetSousCategoriesQueryHandler : ResponseHandler, IRequestHandler<GetSousCategoriesListQuery, Response<List<SousCategorieDto>>>
{
    #region Fields
    private readonly IRepositorySousCategorie _repository;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors
    public GetSousCategoriesQueryHandler(IRepositorySousCategorie repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    #endregion

    #region Handle functions
    public async Task<Response<List<SousCategorieDto>>> Handle(GetSousCategoriesListQuery request, CancellationToken cancellationToken)
    {
        var categorieList = await _repository.GetAllAsync();
        var categorieListMapper = _mapper.Map<List<SousCategorieDto>>(categorieList);
        return Success(categorieListMapper);
    }
    #endregion

}
