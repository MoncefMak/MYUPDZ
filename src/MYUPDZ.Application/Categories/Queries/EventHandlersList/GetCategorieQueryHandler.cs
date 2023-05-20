using AutoMapper;
using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Categories.Queries.EventHandlersList;

public class GetCategorieQueryHandler : ResponseHandler, IRequestHandler<GetCategorieListQuery, Response<List<CategorieDto>>>
{
    #region Fields
    private readonly IRepositoryCategorie _repository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCategorieQueryHandler(IRepositoryCategorie repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    #endregion

    #region Handle functions
    public async Task<Response<List<CategorieDto>>> Handle(GetCategorieListQuery request, CancellationToken cancellationToken)
    {
        var categorieList = await _repository.GetAllAsync();
        var categorieListMapper = _mapper.Map<List<CategorieDto>>(categorieList);
        return Success(categorieListMapper);
    }
    #endregion

}
