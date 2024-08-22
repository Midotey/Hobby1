using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hobby1.Models
{
    public class Chat
    {
        [Required]
        public int Id { get; set; }
        //[ForeignKey("User")]
        //public string UserId { get; set; } = null!;
        //public User? User { get; set; }
        [NotMapped]
        public List<User> Users { get; set; } = new List<User>();
        [NotMapped]
        public List<Text> Texts { get; set; } = new List<Text>();
    }
}
