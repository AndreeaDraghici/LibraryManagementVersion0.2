using System.ComponentModel.DataAnnotations;

namespace WebApplicationFinal.Models
{
    public class Author
    {
        [Key]
        public int author_id { get; set; }
        public string? name { get; set; }

        public AuthorBook? authorBooks { get; set; }

    }
}
