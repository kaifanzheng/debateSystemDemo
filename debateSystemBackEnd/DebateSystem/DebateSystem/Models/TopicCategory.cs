using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebateSystem.Models
{
    public class TopicCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Topic name cannot be empty")]
        public string CategoryName { get; set; }
        [NotMapped]
        public IFormFile CategoryImg { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}
