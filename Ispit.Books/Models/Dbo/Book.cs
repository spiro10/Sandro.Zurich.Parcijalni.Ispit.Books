using System.ComponentModel.DataAnnotations;

namespace Ispit.Books.Models.Dbo
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted {  get; set; }
        public string Name { get; set; }
        public Author? Author { get; set; }
        public int? AuthorId { get; set; }
        public Publisher? Publisher { get; set; }
        public int? PublisherId { get; set;}
    }
}
