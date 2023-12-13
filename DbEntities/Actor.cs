using System;
using System.Collections.Generic;

namespace EcommerceTickets.DbEntities
{
    public partial class Actor
    {
        public Actor()
        {
            ActorMovies = new HashSet<ActorMovie>();
        }

        public int ActorId { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? ActorFullName { get; set; }
        public string? ActorBio { get; set; }

        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
