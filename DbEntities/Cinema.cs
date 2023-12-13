using System;
using System.Collections.Generic;

namespace EcommerceTickets.DbEntities
{
    public partial class Cinema
    {
        public Cinema()
        {
            Movies = new HashSet<Movie>();
        }

        public int CinemaId { get; set; }
        public string? Logo { get; set; }
        public string? CinemaName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
