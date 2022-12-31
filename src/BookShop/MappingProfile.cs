using AutoMapper;
using Data.DTOs;
using Core.Entities;

namespace BookShop;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorDto>()
        .ForMember(a => a.BookCount, opt => opt.MapFrom(src => src.Books.Count));
        CreateMap<Book, BookDto>();
        CreateMap<Genre, GenreDto>();
        CreateMap<Book, BookDetailsDto>()
        .ForMember(c => c.Genre, opt => opt.MapFrom(src => src.Genre))
        .ForMember(c => c.Authors, opt => opt.MapFrom(src => src.Authors));
        // CreateMap<UserForRegistrationDto, User>();
    }
}
