using AutoMapper;
using MYUPDZ.Application.Common.Models;
using MYUPDZ.Domain.Entities;

namespace MYUPDZ.Application.Mapping;

public partial class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<Categorie, CategorieDto>().ReverseMap();
        CreateMap<SousCategorie, SousCategorieDto>()
            .ForMember(dest => dest.Categorie, opt => opt.MapFrom(src => src.Categorie.Designation));
        CreateMap<Fonctionnaire, FonctionnaireDto>().ReverseMap();
    }
}
