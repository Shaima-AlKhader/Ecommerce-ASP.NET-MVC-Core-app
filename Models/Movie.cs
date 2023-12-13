
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceTeckits.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        


        // Relationships
        public virtual ICollection<ActorMovie> ActorMovies { get; set; }


        // Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public string CinemaName { get; set; }
        public Cinema Cinema { get; set; }

        // Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
