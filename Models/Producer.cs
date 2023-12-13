
using System.ComponentModel.DataAnnotations;

namespace EcommerceTeckits.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string ProducerFullName { get; set; }
        public string ProducerBio { get; set; }


        // Relationships
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
