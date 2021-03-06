﻿using Music3.Domain.AlbumAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Domain.ArtistAgg
{
    public class ArtistAlbum
    {
        public long ArtistId { get; set; }
        public long AlbumId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Album Album { get; set; }

    }
}
