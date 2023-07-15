using AutoMapper;
using DataAccess.Dto;
using DataAccess.Models;

namespace DataAccess.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SpaceXEventModel, SpaceXEventDto>();
    }
}