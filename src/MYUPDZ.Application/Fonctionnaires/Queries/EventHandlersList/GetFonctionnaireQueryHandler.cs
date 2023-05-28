using AutoMapper;
using MediatR;
using MYUPDZ.Application.Common.Interfaces.Repository;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Fonctionnaires.Queries.EventHandlersList;

public class GetFonctionnaireQueryHandler : IRequestHandler<GetFonctionnaireListQuery, List<FonctionnaireDto>>
{
    #region Fields
    private readonly IRepositoryFonctionnaire _repositoryFonctionnaire;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetFonctionnaireQueryHandler(IRepositoryFonctionnaire repositoryFonctionnaire, IMapper mapper)
    {
        _repositoryFonctionnaire = repositoryFonctionnaire;
        _mapper = mapper;
    }
    #endregion

    #region Handle functions
    public async Task<List<FonctionnaireDto>> Handle(GetFonctionnaireListQuery request, CancellationToken cancellationToken)
    {
        var fonctionnaireList = await _repositoryFonctionnaire.GetAllAsync();
        return _mapper.Map<List<FonctionnaireDto>>(fonctionnaireList);
    }
    #endregion

}
