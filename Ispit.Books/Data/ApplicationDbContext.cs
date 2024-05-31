using Ispit.Books.Models.Dbo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Books.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            for (int i = 1; i < 6; i++)
            {
                builder.Entity<Author>().HasData(
                new Author
                {
                    Id = i,
                    FullName = "Author" + i
                });
            }

            for (int i = 1; i < 4; i++)
            {
                builder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = i,
                    Name = "Publisher" + i
                });
            }



            base.OnModelCreating(builder);
        }
    }
}

