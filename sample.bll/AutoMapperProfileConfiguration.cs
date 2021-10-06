using AutoMapper;
using OB_Net_Core_Tutorial.DTO;
using OB_Net_Core_Tutorial.Model;


namespace OB_Net_Core_Tutorial
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<BookDTO, Book>();
            CreateMap<Book, BookDTO>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, BookDTO>();
        }
    }
}
