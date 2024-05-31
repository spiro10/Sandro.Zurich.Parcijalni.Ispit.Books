using AutoMapper;
using Ispit.Books.Data;
using Ispit.Books.Models.Dbo;
using Ispit.Books.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ispit.Books.Services.Implementations
{
    public class BooksService : IBooksService
    {


        public ApplicationDbContext db { get; set; }
        public UserManager<ApplicationUser> userManager { get; set; }
        public IMapper mapper { get; set; }


        public BooksService(ApplicationDbContext db, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.db = db;
            this.userManager = userManager;
            this.mapper = mapper;
        }


        public List<Book> GetBooks()
        {
            var dbos = db.Books.Include(x => x.Author).Include(x => x.Publisher)
                .Where(x => !x.IsDeleted).ToList();
            return dbos;
        }

        public void DeleteBook(int id)
        {
            var book = db.Books.FirstOrDefault(x => x.Id == id);
            book.IsDeleted = true;
            db.SaveChanges();
        }

        public void CreateBook(Book model)
        {
            db.Books.Add(model);
            db.SaveChanges();
        }

        public void EditBook(Book model)
        {
            var dbo = db.Books.Include(x => x.Author).Include(x => x.Publisher)
                .FirstOrDefault(x => x.Id == model.Id);
            mapper.Map(model, dbo);
            db.SaveChanges();
        }

        public Book GetBook(int id)
        {
            var dbo = db.Books.Include(x => x.Author).Include(x => x.Publisher)
                .FirstOrDefault(x => x.Id == id);
            return dbo;
        }

    }
}
