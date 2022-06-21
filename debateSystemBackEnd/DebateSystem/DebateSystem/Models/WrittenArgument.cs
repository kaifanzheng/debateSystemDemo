using System.ComponentModel.DataAnnotations;

namespace DebateSystem.Models
{
    public class WrittenArgument
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Argument cannot be empty")]
        public string Argument { get; set; }
        public int ApplicationUserId { get; set; }
        public int TopicId { get; set; }
    }
}
