using AutoMapper;
using NetCoreRestAPI.Models;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<Language, LanguageDto>();
        CreateMap<LanguageDto, Language>();
    }
}