using System;
using System.Collections.Generic;

namespace EcommerceTickets.DbEntities
{
    public partial class Producer
    {
        public Producer()
        {
            Movies = new HashSet<Movie>();
        }

        public int ProducerId { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? ProducerFullName { get; set; }
        public string? ProducerBio { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
