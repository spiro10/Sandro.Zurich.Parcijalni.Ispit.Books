using AutoMapper;
using Ispit.Books.Models.Dbo;

namespace Ispit.Books.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Book, Book>();
            CreateMap<ApplicationUser, ApplicationUserViewModel>();
        }
    }
}
