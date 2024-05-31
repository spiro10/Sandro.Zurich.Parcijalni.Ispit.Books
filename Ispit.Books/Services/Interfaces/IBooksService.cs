using AutoMapper;
using Ispit.Books.Data;
using Ispit.Books.Models.Dbo;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Ispit.Books.Services.Interfaces
{
    public interface IBooksService
    {
        ApplicationDbContext db { get; set; }
        IMapper mapper { get; set; }
        UserManager<ApplicationUser> userManager { get; set; }

        void CreateBook(Book model);
        void DeleteBook(int id);
        void EditBook(Book model);
        Book GetBook(int id);
        List<Book> GetBooks();
    }
}