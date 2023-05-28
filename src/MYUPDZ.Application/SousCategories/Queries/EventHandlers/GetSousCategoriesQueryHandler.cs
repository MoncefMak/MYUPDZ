using AutoMapper;
using MediatR;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.SousCategories.Queries.EventHandlers;

public class GetSousCategoriesQueryHandler : IRequestHandler<GetSousCategoriesListQuery, List<SousCategorieDto>>
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
    public async Task<List<SousCategorieDto>> Handle(GetSousCategoriesListQuery request, CancellationToken cancellationToken)
    {
        var categorieList = await _repository.GetAllAsync();
        return _mapper.Map<List<SousCategorieDto>>(categorieList);
    }
    #endregion

}
