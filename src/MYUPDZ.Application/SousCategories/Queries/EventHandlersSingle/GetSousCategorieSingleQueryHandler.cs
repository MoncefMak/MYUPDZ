using AutoMapper;
using MediatR;
using MYUPDZ.Application.Common.Exceptions;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.SousCategories.Queries.EventHandlersSingle;

public class GetSousCategorieSingleQueryHandler : IRequestHandler<GetSousCategorieSingleQuery, SousCategorieDto>
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
    public async Task<SousCategorieDto> Handle(GetSousCategorieSingleQuery request, CancellationToken cancellationToken)
    {
        var categorie = await _repository.GetByIdAsync(request.Id);
        if (categorie == null) throw new NotFoundException("SousCategorie not found.");
        return _mapper.Map<SousCategorieDto>(categorie);
    }
    #endregion

}
