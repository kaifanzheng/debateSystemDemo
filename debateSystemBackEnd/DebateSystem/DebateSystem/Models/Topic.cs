using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebateSystem.Models
{
    public class Topic
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Topic name cannot be empty")]
        public string TopicName { get; set; }
        [Required(ErrorMessage = "Popularity cannot be empty")]
        public int Popularity { get; set; }
        [NotMapped]
        public IFormFile TopicImg { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers {get; set;}
        public ICollection<WrittenArgument> WrittenArguments { get; set; }
        public ICollection<TopicTag> topicTags { get; set; }
    }
}
