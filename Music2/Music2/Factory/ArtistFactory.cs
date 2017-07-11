using Music2.Domain.ArtistAgg;
using Music2.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Factory
{
    public static class ArtistFactory
    {
        public static Artist CreateArtist(string displayname, string firstname, string lastname, ArtistDetailsDto artistDetailsDto )
        {
            Artist artist = new Artist(displayname, firstname, lastname);
            artist.CreateArtistDetails(artistDetailsDto.StageName);

            return artist;
        }
    }
}
