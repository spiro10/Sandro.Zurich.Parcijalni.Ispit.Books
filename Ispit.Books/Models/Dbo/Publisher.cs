using System.ComponentModel.DataAnnotations;

namespace Ispit.Books.Models.Dbo
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Publisher")]
        public string Name { get; set; }
    }
}
