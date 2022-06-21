using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebateSystem.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username cannot be empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; }
        [NotMapped]
        public IFormFile ProfilePicture { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<WrittenArgument> writtenArguments { get; set; }
    }
}
