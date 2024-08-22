using Hobby1.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hobby1.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }
        //[ForeignKey]
        [NotMapped]
        public List<Chat> Chats { get; set; } = new List<Chat>();


    }

}
