using Music2.Domain.TrackAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Domain.AlbumAgg
{
    public class AlbumTrack
    {
        public long AlbumId { get; set; }
        public long TrackId { get; set; }
        public Album Album { get; set; }
        public Track Track { get; set; }
    }
}
