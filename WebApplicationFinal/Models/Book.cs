using System.ComponentModel.DataAnnotations;

namespace WebApplicationFinal.Models
{
    public class Book
    {
        [Key]
        public int book_id { get; set; }

        [Display(Name = "Name")]
        public string? name { get; set; }

        [Display(Name = "Publisher")]
        public string? publisher { get; set; }
        [Display(Name = "Category")]
        public string? category_type { get; set; }
        public ICollection<Category>? Category { get; set; }
  
        [Display(Name = "Book")]
        public string? photoURL { get; set; }
    }
}
