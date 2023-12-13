using System.ComponentModel.DataAnnotations;

namespace EcommerceTeckits.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        public string Logo { get; set; }
        public string CinemaName { get; set; }
        public string Description { get; set; }


        // Relationships
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
