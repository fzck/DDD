using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Domain.ArtistAgg
{
    public class ArtistDetails : ValueObject
    {
        public string StageName { get; set; }
        public long ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        public ArtistDetails() { }

        public ArtistDetails(Artist artist, string stageName)
        {
            Artist = artist;
            StageName = stageName;
        }

        public ArtistDetails(string stageName)
        {
            
            StageName = stageName;
        }


    }
}
