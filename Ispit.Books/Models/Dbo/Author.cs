using System.ComponentModel.DataAnnotations;

namespace Ispit.Books.Models.Dbo
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Author")]
        public string FullName { get; set; }
    }
}
