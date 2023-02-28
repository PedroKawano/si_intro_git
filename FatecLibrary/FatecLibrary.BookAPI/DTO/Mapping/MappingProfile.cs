using AutoMapper;
using FatecLibrary.BookAPI.DTO.Entities;
using FatecLibrary.BookAPI.Models.Entities;

namespace FatecLibrary.BookAPI.DTO.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Publishing, PublishingDTO>().ReverseMap();

            CreateMap<BookDTO, Book>();

            CreateMap<Book, BookDTO>().ForMember(
                P => P.PublishingName,
                options => options.MapFrom(src => src.Publishing.Name)
                );
        }
    }
}
