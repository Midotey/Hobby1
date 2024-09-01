using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hobby1.Models
{
    public class Text
    {
        [Required]
        public int Id { get; set; }
        public string? TextData { get; set; }
        [Required]
        public int ChatId { get; set; } /*= null!;*/
        //[NotMapped]
        public Chat Chat { get; set; }

    }
}
