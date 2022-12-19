using System.ComponentModel.DataAnnotations;

namespace WebApplicationFinal.Models
{
    public class Message
    {
        [Key]
        public int message_id { get; set; }
        public Book? Book { get; set; }

        public string? subject { get; set; }
    }
}
