using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebateSystem.Models
{
    public class TopicTag
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "tag name cannot be empty")]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}
