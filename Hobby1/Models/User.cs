using Hobby1.Data.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hobby1.Models
{
    public class User : IdentityUser
    {
        //[Required]
        //public string Id { get; set; }
        [Required]
        //[Remote(, ErrorMessage="User with that nickname already exists!")]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }
        //[ForeignKey]
        [NotMapped]
        public List<Chat> Chats { get; set; } = new List<Chat>();


    }

}
