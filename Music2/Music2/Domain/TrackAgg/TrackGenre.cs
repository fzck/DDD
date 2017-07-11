using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Domain.TrackAgg
{
    public class TrackGenre
    {
        public long TrackId { get; set; }
        public long GenreId { get; set; }
        public virtual Track Track { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
