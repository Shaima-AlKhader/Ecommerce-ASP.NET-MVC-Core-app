
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EcommerceTeckits.Models
{
    public class Actor
    {
        [Required]
        public int ActorId { get; set; }

        
        [Required(AllowEmptyStrings = false, ErrorMessage = "This feild is requirmet")]
        public string  ProfilePictureUrl { get; set; }

      
        [Required(AllowEmptyStrings = false, ErrorMessage = "This feild is requirmet")]
        public string ActorFullName { get; set; }

      
        [Required(AllowEmptyStrings = false, ErrorMessage = "This feild is requirmet")]
        public string ActorBio { get; set; }

       

        // Relationships
        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
