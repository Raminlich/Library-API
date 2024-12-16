using AutoMapper;
using Library_API.DTOs;
using Library_API.Models;

namespace Library_API.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AuthorDto, Author>();
            CreateMap<Author,AuthorDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Book,BookDto>();
        }
    }
}
