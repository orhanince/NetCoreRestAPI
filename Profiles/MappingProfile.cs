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
        CreateMap<Publisher, PublisherDto>();
        CreateMap<PublisherDto, Publisher>();
        CreateMap<Author, AuthorDto>();
        CreateMap<AuthorDto, Author>();
        CreateMap<Book, BookDto>().ForMember(dest => dest.Authors, opt => opt.MapFrom(src => 
                (src.BookAuthors ?? Enumerable.Empty<BookAuthor>()).Select(ba => new Author 
                { 
                    Id = ba.Author.Id, 
                    Name = ba.Author.Name,
                    Surname = ba.Author.Surname
                })))
                .ForMember(dest => dest.language, opt => opt.MapFrom(src => src.Language != null ? src.Language.Name : null))
                .ForMember(dest => dest.publisher, opt => opt.MapFrom(src => src.Publisher != null ? src.Publisher.Name : null));
        CreateMap<BookAuthor, AuthorDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Author.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Author.Surname));
        CreateMap<BookDto, Book>();
        CreateMap<Book, BookWithAuthorsDto>();
        CreateMap<BookWithAuthorsDto, Book>();
    }
}