using System.ComponentModel.DataAnnotations;

namespace Hobby1.Models
{
    public class Text
    {
        [Required]
        public int Id { get; set; }
        public string? TextData { get; set; }
        public int ChatId { get; set; } /*= null!;*/
        public Chat Chat { get; set; }

    }
}
