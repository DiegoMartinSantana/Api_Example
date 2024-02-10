using Api.DTOs;
using Api.Models;
using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace Api.Mappers
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<BeerInsertDto, Beer>()
                .ForMember(dto =>dto.NameBeer, m => m.MapFrom(b => b.Name));

            CreateMap<Beer, BeerDto>()
                 .ForMember(beer => beer.Name, m => m.MapFrom(b => b.NameBeer))
                 .ForMember(beer => beer.Id, m => m.MapFrom(b => b.IdBeer));

        }
    }
}
