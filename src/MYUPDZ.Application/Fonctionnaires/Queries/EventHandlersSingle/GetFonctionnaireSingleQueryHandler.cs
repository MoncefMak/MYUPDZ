using AutoMapper;
using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Fonctionnaires.Queries.EventHandlersSingle;

public class GetFonctionnaireSingleQueryHandler : ResponseHandler, IRequestHandler<GetFonctionnaireSingleQuery, Response<FonctionnaireDto>>
{
    #region Fields
    private readonly IRepositoryFonctionnaire _repositoryFonctionnaire;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetFonctionnaireSingleQueryHandler(IRepositoryFonctionnaire repositoryFonctionnaire, IMapper mapper)
    {
        _repositoryFonctionnaire = repositoryFonctionnaire;
        _mapper = mapper;
    }
    #endregion

    #region Handle functions
    public async Task<Response<FonctionnaireDto>> Handle(GetFonctionnaireSingleQuery request, CancellationToken cancellationToken)
    {
        var fonctionnaire = await _repositoryFonctionnaire.GetByIdAsync(request.Id);
        if (fonctionnaire == null) return NotFound<FonctionnaireDto>("Object");
        var fonctionnaireMapper = _mapper.Map<FonctionnaireDto>(fonctionnaire);
        return Success(fonctionnaireMapper);
    }
    #endregion

}
