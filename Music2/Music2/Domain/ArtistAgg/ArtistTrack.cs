using Music2.Domain.TrackAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Domain.ArtistAgg
{
    public class ArtistTrack
    {
        public long ArtistId { get; set; }
        public long TrackId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Track Track { get; set; }

    }
}
